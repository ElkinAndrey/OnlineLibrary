using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
namespace OnlineLibraryAPI.Presentation.ServiceConfigurations;

public static class SwaggerGenConfiguration
{
    public static void AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            options =>
            {
                options.AddSecurityDefinition("oauth2",
                    new OpenApiSecurityScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme.",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                    }
                );
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            }
        );
    }
}
