﻿using FestCover.Application.Common.Models.Auth;
using FestCover.Contracts.Authentication;
using Mapster;

namespace FestCover.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(UpdateUserRequest User, string UserId), UpdateUserAuthModel>().

            Map(dest => dest.UserId, src => src.UserId).
            Map(dest => dest.Username, src => src.User.Username).
            Map(dest => dest.Email, src => src.User.Email).
            Map(dest => dest.CurrentPassword, src => src.User.CurrentPassword).
            Map(dest => dest.Password, src => src.User.Password).
            Map(dest => dest.Password, src => src.User.Password).
            Map(dest => dest.Password2, src => src.User.Password2).
            Map(dest => dest.Picture, src => ConvertToFile(src.User.File)).
            Map(dest => dest.Extension, src => Path.GetExtension(src.User.File.FileName)).
            Map(dest => dest.ContentType, src => src.User.File.ContentType);

        }

        private byte[] ConvertToFile(IFormFile file)
        {
            byte[] data;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                data = target.ToArray();
                return data;
            }
        }
    }
}
