using AfterLife.Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using FestCover.Application.Common.Contracts;
using FestCover.Application.Common.Persistence;
using FestCover.Infrastructure.Common.Persistence;
using FestCover.Infrastructure.Common.Persistence.Identity;
using FestCover.Infrastructure.Common.Persistence.Interceptors;
using FestCover.Infrastructure.Common.Persistence.Repositories;
using FestCover.Infrastructure.Persistence.Identity;
using FestCover.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestCover.Infrastructure.Common.Services;

namespace FestCover.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddScoped<IStorageService, StorageService>();
            var azureSettings = configuration.GetSection("Azure");
            services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.AddBlobServiceClient(azureSettings.GetSection("Storage").Value);
            });

            services.AddPersistance(configuration).AddAuth(configuration);
            services.AddScoped<IImageService, ImageService>();

            return services;
        }
        public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<FestCoverDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumContentRepository, AlbumContentRepository>();
            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<AuditInterceptor>();

            return services;
        }
        public static IServiceCollection AddAuth(
       this IServiceCollection services,
       ConfigurationManager configuration)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITokenClaimService, TokenClaimService>();
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FestCoverDbContext>().AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider).
                AddUserManager<UserManager<User>>().AddRoleManager<RoleManager<Role>>();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            });
            var jwtSettings = configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value)),
                    ClockSkew = TimeSpan.Zero
                };

                //options.Events = new JwtBearerEvents
                //{
                //    OnMessageReceived = ctx =>
                //    {
                //        ctx.Request.Cookies.TryGetValue("accessToken", out var accessToken);
                //        if (!string.IsNullOrEmpty(accessToken))
                //        {
                //            ctx.Token = accessToken;
                //        }
                //        return Task.CompletedTask;
                //    }
                //};
            });
            return services;
        }
    }
}
