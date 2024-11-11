﻿using FestCover.Application.Common.Models.Albums;
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
            Map(dest => dest.Url, src => src.Album.Url).
            Map(dest => dest.AllowPublicUpload, src => src.Album.AllowPublicUpload).
            Map(dest => dest.Contents, src => src.AlbumContent);

            config.NewConfig<(Album Album, AlbumContent Content), AlbumContentPendingModel>().

           Map(dest => dest.Id, src => src.Content.Id).
           Map(dest => dest.AlbumId, src => src.Album.Id).
           Map(dest => dest.AlbumName, src => src.Album.Name).
           Map(dest => dest.Url, src => src.Content.Url).
           Map(dest => dest.PhoneNumber, src => src.Content.PhoneNumber);


        }
    }
}
