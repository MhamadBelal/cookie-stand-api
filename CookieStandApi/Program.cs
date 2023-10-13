using CookieStandApi.Data;
using CookieStandApi.Models.Interfaces;
using CookieStandApi.Models.services;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<CookieStandDBContext>(options => options.UseSqlServer(connString));

        builder.Services.AddTransient<ICookieStand, CookieStandService>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }
                );
        });

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "CookieStand API",
                Version = "v1",
            });
        });

        var app = builder.Build();

        app.UseCors();

        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/api/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(aptions =>
        {
            aptions.SwaggerEndpoint("/api/v1/swagger.json", "CookieStand API");
            aptions.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();



        app.UseAuthorization();


        app.MapControllers();


        app.Run();
    }
}