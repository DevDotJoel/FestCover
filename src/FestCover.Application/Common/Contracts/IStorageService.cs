using ErrorOr;

namespace FestCover.Application.Common.Contracts
{
    public interface IStorageService
    {
        Task<ErrorOr<string>> AddFile(string contentType, string path, byte[] file);
        Task<ErrorOr<Success>> RemoveFile(string path);
        Task<ErrorOr<Success>> RemoveContainer(string containerPath);
        Task<ErrorOr<long>> GetFolderSizeAsync(string path);
        Task<ErrorOr<string>> GetDownloadImagesUrlAsync(List<string> fileNames,string pathToDownload);
    }
}
