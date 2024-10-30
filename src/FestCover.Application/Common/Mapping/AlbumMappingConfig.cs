using FestCover.Application.Common.Models.Albums;
using FestCover.Domain.AlbumContents;
using FestCover.Domain.Albums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Mapping
{
    public class AlbumMappingConfig:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Album Album, List<AlbumContent> AlbumContent), AlbumDetailModel>().
              
            Map(dest => dest.Id, src => src.Album.Id).
            Map(dest => dest.Name, src => src.Album.Name).
            Map(dest => dest.OriginalAlbumUrlImage, src => src.Album.OriginalAlbumUrlImage).
            Map(dest => dest.MediumAlbumUrlImage, src => src.Album.MediumAlbumUrlImage).
            Map(dest => dest.LargeAlbumUrlImage, src => src.Album.LargeAlbumUrlImage).
            Map(dest => dest.Contents, src => src.AlbumContent);


        }
    }
}
