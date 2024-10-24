
using Mapster;
using FestCover.Api.Services;
using FestCover.Application.Common.Contracts;
using System.Reflection;


namespace FestCover.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddCors(o => o.AddPolicy("frontend", builder =>
            {
                builder.AllowCredentials().
                        SetIsOriginAllowed(host => true).
                        AllowAnyMethod().
                        AllowAnyHeader();
            }));
            services.AddProblemDetails();
            services.AddScoped<IUserService, UserService>();
            return services;
        }

    }
}
