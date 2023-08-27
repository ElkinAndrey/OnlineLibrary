using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineLibraryAPI.Domain.Constants;
using System.Text;

namespace OnlineLibraryAPI.Presentation.ServiceConfigurations;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = TokenConstants.Issuer,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(TokenConstants.TokenKey)),
                    ValidateIssuerSigningKey = true
                };
            }
        );
    }
}
