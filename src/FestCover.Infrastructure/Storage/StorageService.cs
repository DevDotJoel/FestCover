
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ErrorOr;
using FestCover.Application.Common.Contracts;
using System.IO;

namespace FestCover.Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        private string container = "users";
        private readonly BlobServiceClient _blobServiceClient;
        public StorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<ErrorOr<string>> AddFile(string contentType, string path, byte[] file)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(container);
                var result = await containerClient.ExistsAsync();
                if (!result)
                {
                    var acessPolicyType = PublicAccessType.Blob;
                    await containerClient.CreateIfNotExistsAsync(acessPolicyType);
                }
                BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders();
                blobHttpHeaders.ContentType = contentType;
                using (var fileStream = new MemoryStream(file))
                {
                    await containerClient.UploadBlobAsync(path, fileStream);
                    var blobClient = containerClient.GetBlobClient(path);
                    blobClient.SetHttpHeaders(blobHttpHeaders);
                    var blobUrl = blobClient.Uri.ToString();
                    return blobUrl;
                }
            }
            catch (Exception ex)
            {

                return Error.Failure(description: ex.Message);
            }

        }

        public async Task<ErrorOr<Success>> RemoveFile(string path)
        {

            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            if (await containerClient.ExistsAsync())
            {
                var blob = containerClient.GetBlobClient(path);
                var exists = await blob.ExistsAsync();
                if (exists)
                {

                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    return Result.Success;
                }
                else
                {
                    return Error.NotFound(description: "File not found");
                }
            }

            return Error.NotFound(description: "An error occured");
        }

        public async Task<ErrorOr<Success>> RemoveContainer(string containerPath)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(container);
                if (await containerClient.ExistsAsync())
                {
                    var blobItems = containerClient.GetBlobsAsync(prefix: containerPath);
                    await foreach (BlobItem blobItem in blobItems)
                    {
                        BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);
                        await blobClient.DeleteIfExistsAsync();
                    }
                    return Result.Success;

                }
                else
                {
                    return Error.NotFound(description: "Container not found");
                }
            }
            catch (Exception ex )
            {

                return Error.Failure(description:ex.Message);
            }
         

        }
    }
}
