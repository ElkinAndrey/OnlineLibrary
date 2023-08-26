using Microsoft.IdentityModel.Tokens;
using OnlineLibraryAPI.Domain.Constants;
using OnlineLibraryAPI.Domain.Entities;
using OnlineLibraryAPI.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace OnlineLibraryAPI.Services.Implementations;

public class JwtTokenService : ITokenService
{
    public string CreateAccessToken(User user)
    {
        var issuer = TokenConstants.Issuer;
        var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email), new Claim(ClaimTypes.Role, user.Role.Name), new Claim("UserId", user.Role.Name) };
        var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds((double)TokenConstants.AccessTokenExpires));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConstants.TokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(issuer, null, claims, null, expires, credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
