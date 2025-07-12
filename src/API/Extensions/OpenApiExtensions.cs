using Microsoft.OpenApi.Models;

namespace API.Extensions;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NovaStarterKit API",
                Version = "v1",
                Description = "Clean architecture ASP.NET Core 9 API starter kit"
            });
        });

        return services;
    }

    public static WebApplication UseOpenApiDocumentation(this WebApplication app)
    {
        app.UseSwagger();

        app.UseReDoc(options =>
        {
            options.RoutePrefix = "";
            options.DocumentTitle = "NovaStarterKit API Documentation";
            options.SpecUrl = "/swagger/v1/swagger.json";
        });

        return app;
    }
}
