using Mapster;
using FestCover.Application.Albums.Commands.CreateAlbum;
using FestCover.Application.Albums.Commands.UpdateAlbum;
using FestCover.Contracts.Albums;
using FestCover.Application.AlbumContents.Commands.CreateAlbumContent;

namespace FestCover.Api.Common.Mapping
{
    public class AlbumMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
               .NewConfig<CreateAlbumRequest, CreateAlbumCommand>()
               .Map(dest => dest.IsPublic, src => src.IsPublic == "1" ? true : false)
               .Map(dest => dest.AllowPublicUpload, src => src.AllowPublicUpload=="1"?true:false)
                .Map(dest => dest.ReviewUploadedContent, src => src.ReviewUploadedContent == "1" ? true : false)
                .Map(dest => dest.AlbumImage, src => ConvertToFile(src.AlbumImage));

            config
              .NewConfig<UpdateAlbumRequest, UpdateAlbumCommand>()
                 .Map(dest => dest.IsPublic, src => src.IsPublic == "1" ? true : false)
                .Map(dest => dest.AllowPublicUpload, src => src.AllowPublicUpload == "1" ? true : false)
                .Map(dest => dest.ReviewUploadedContent, src => src.ReviewUploadedContent == "1" ? true : false)
               .Map(dest => dest.AlbumImage, src => src.AlbumImage !=null?ConvertToFile(src.AlbumImage):null);
            config
             .NewConfig<CreateAlbumContentRequest, CreateAlbumContentCommand>()
              .Map(dest => dest.AlbumContentImages, src => src.AlbumContentImages.ConvertAll(c=> ConvertToFile(c)));

        }
        private AlbumImageCommand ConvertToFile(IFormFile file)
        {
            byte[] data;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                data = target.ToArray();
                return new AlbumImageCommand(data, file.FileName, Path.GetExtension(file.FileName), file.ContentType);
            }
        }
    }
}
