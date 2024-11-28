
using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using ErrorOr;
using FestCover.Application.Common.Contracts;
using System.IO;
using System.IO.Compression;

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
                // Get the container client
                var containerClient = _blobServiceClient.GetBlobContainerClient(container);

                // Check if the container exists and create if not
                if (!await containerClient.ExistsAsync())
                {
                    await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);  // Adjust access type as needed
                }

                // Get the blob client for the specific file path
                var blobClient = containerClient.GetBlobClient(path);

                // Create Blob HTTP Headers
                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType
                };

                // Upload the file using a MemoryStream
                using (var fileStream = new MemoryStream(file))
                {
                    // Upload the blob with headers set in the same operation
                    await blobClient.UploadAsync(fileStream, new BlobUploadOptions
                    {
                        HttpHeaders = blobHttpHeaders
                    });
                    // Get the blob URL after upload
                    var blobUrl = blobClient.Uri.ToString();
                    return blobUrl;
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Handle specific Azure request failures (e.g., container not found)
                return Error.Failure(description: "Container not found: " + ex.Message);
            }
            catch (RequestFailedException ex)
            {
                // Handle other Azure-specific errors
                return Error.Failure(description: "Blob service error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other general exceptions
                return Error.Failure(description: "An unexpected error occurred: " + ex.Message);
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

        public async Task<ErrorOr<long>> GetFolderSizeAsync(string path)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(container);
                if (await containerClient.ExistsAsync())
                {
                    long totalSize = 0;
                    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(prefix: path))
                    {
                        // Get blob properties (size)
                        BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);
                        BlobProperties properties = await blobClient.GetPropertiesAsync();
                        totalSize += properties.ContentLength;
                    }

                    return totalSize;

                }
                else
                {
                    return Error.NotFound(description: "Container not found");
                }
            }
            catch (Exception ex)
            {

                return Error.Failure(description: ex.Message);
            }
        }

        public async Task<ErrorOr<MemoryStream>> GetDownloadImageAsync( List<string> fileNames)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            MemoryStream zipStream = new MemoryStream();

            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var fileName in fileNames)
                {
                    BlobClient blobClient = containerClient.GetBlobClient(fileName);
                    var blobDownloadInfo = await blobClient.DownloadAsync();

                    ZipArchiveEntry zipEntry = zip.CreateEntry(fileName);

                    using Stream entryStream = zipEntry.Open();
                    await blobDownloadInfo.Value.Content.CopyToAsync(entryStream);
                }
            }

            // Reset the stream position to the beginning before returning it
            zipStream.Position = 0;

            return zipStream;

        }
    }
}
