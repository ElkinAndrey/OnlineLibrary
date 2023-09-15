using OnlineLibraryAPI.Domain.Constants;
using System.Security.Claims;

namespace OnlineLibraryAPI.Presentation.ServiceConfigurations;

public static class AuthorizationConfiguration
{
    public static void AddAuthorizationConfiguration(this IServiceCollection services) 
    {
        services.AddAuthorization(
            options =>
            {
                options.AddPolicy(RoleConstants.UserRole.Name, builder =>
                {
                    builder.RequireAssertion
                    (x =>
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.UserRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.ManagerRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.SuperManagerRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.AdminRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.RootRole.Name)
                    );
                });
                options.AddPolicy(RoleConstants.ManagerRole.Name, builder =>
                {
                    builder.RequireAssertion
                    (x =>
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.ManagerRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.SuperManagerRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.AdminRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.RootRole.Name)
                    );
                });
                options.AddPolicy(RoleConstants.SuperManagerRole.Name, builder =>
                {
                    builder.RequireAssertion
                    (x =>
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.SuperManagerRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.AdminRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.RootRole.Name)
                    );
                });
                options.AddPolicy(RoleConstants.AdminRole.Name, builder =>
                {
                    builder.RequireAssertion
                    (x =>
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.AdminRole.Name) ||
                        x.User.HasClaim(ClaimTypes.Role, RoleConstants.RootRole.Name)
                    );
                });
                options.AddPolicy(RoleConstants.RootRole.Name, builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, RoleConstants.RootRole.Name);
                });
            }
        );
    }
}
