using FestCover.Api;
using FestCover.Infrastructure;
using FestCover.Application;
using Microsoft.AspNetCore.Builder;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.HttpOverrides;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = 50 * 1024 * 1024);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddWebApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    //app.Use((context, next) =>
    //{
    //    context.Request.Host = new HostString(".festcoverapi.festcover.com");
    //    context.Request.Scheme = "https";
    //    return next(context);
    //});
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("frontend");
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
