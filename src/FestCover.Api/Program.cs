using FestCover.Api;
using FestCover.Infrastructure;
using FestCover.Application;
using Microsoft.AspNetCore.Builder;
using SixLabors.ImageSharp;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = 50 * 1024 * 1024);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddWebApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.UseCors("frontend");
}
app.UseSwagger();
app.UseSwaggerUI();

app.Use((context, next) =>
{
    var webAppSettings = builder.Configuration.GetSection("WebApp");
    context.Request.Host = new HostString(webAppSettings.GetSection("BackendHost").Value);
    context.Request.Scheme = "https";
    return next();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
