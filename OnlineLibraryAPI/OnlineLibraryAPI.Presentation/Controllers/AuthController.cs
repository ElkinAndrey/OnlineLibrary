using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineLibraryAPI.Domain.Constants;
using OnlineLibraryAPI.Domain.Entities;
using OnlineLibraryAPI.Presentation.Dto.Auth;
using OnlineLibraryAPI.Services.Abstractions;
using OnlineLibraryAPI.Services.Persistence;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace OnlineLibraryAPI.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private AppDbContext DbContext { get; set; }
    private ITokenService TokenService { get; set; }
    private IPasswordService PasswordService { get; set; }
    private IEmailService EmailService { get; set; }
    public AuthController(AppDbContext dbContext, IPasswordService passwordService, IEmailService emailService, ITokenService tokenService)
    {
        DbContext = dbContext;
        PasswordService = passwordService;
        EmailService = emailService;
        TokenService = tokenService;
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
    {
        if (!await EmailService.IsExistingEmailAsync(registerDto.Email))
        {
            DbContext.Roles.Attach(RoleConstants.UserRole);
            var user = new User {
                Email = EmailService.GetNormalize(registerDto.Email),
                PasswordHash = PasswordService.CreatePasswordHash(registerDto.Password),
                Role = RoleConstants.UserRole
            };
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();
        }
        else 
        {
            //изменить потом обработку ошибок
            throw new Exception("User with this email already exists.");
        }
        return Ok();
    }

    /// <summary>
    /// Войти (получить access- и refresh- токены)
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto) 
    {
        var user = await DbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == EmailService.GetNormalize(loginDto.Email)) 
            ?? throw new Exception("User with this email does not exist.");  //изменить потом обработку ошибок
        if (PasswordService.VerifyPasswordHash(user.PasswordHash, loginDto.Password))
        {
            await SetRefreshToken(TokenService.CreateRefreshToken(user));
            await DeleteExpiredTokensAsync(user);
            return Ok(TokenService.CreateAccessToken(user));
        }
        else
        {
            //изменить потом обработку ошибок
            throw new Exception("Invalid password.");
        }
       
    }
    /// <summary>
    /// Получить новую пару refresh- и access- токенов
    /// </summary>
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        //проверяем валидность присланного refresh-токена
        var refreshToken = await DbContext.RefreshTokens
            .Include(rt => rt.User)
            .ThenInclude(u => u.Role)
            .FirstOrDefaultAsync(t => t.Token == GetRefreshToken())
            ?? throw new Exception("Incorrect refresh token."); //изменить потом обработку ошибок
        if (refreshToken.Expires < DateTime.UtcNow)
            throw new Exception("Refresh token expired."); //изменить потом обработку ошибок
        //генерируем новый access-токен и устанавливаем новый refresh-токен в куки
        await SetRefreshToken(TokenService.CreateRefreshToken(refreshToken.User));
        var accessToken = TokenService.CreateAccessToken(refreshToken.User);
        //удаляем присланный refresh-токен
        DbContext.RefreshTokens.Remove(refreshToken);
        await DbContext.SaveChangesAsync();
        return Ok(accessToken);
    }
    /// <summary>
    /// Выйти из аккаунта на этом устройстве (удалить refresh-токен)
    /// </summary>
    [HttpPost("logout"), Authorize(Policy = "User")]
    public async Task<IActionResult> Logout() 
    {
        var refreshToken = await DbContext.RefreshTokens
           .FirstOrDefaultAsync(t => t.Token == GetRefreshToken())
           ?? throw new Exception("Incorrect refresh token."); //изменить потом обработку ошибок;
        Response.Cookies.Delete("RefreshToken");
        DbContext.RefreshTokens.Remove(refreshToken);
        await DbContext.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Выйти из аккаунта на всех устройствах (удалить все refresh-токены)
    /// </summary>
    [HttpPost("all_logout"), Authorize(Policy = "User")]
    public async Task<IActionResult> AllLogout()
    {
        Response.Cookies.Delete("RefreshToken");
        var id = new Guid(HttpContext.User.FindFirst("UserId")!.Value);
        await DbContext.RefreshTokens.Where(rt => rt.User.Id == id).ExecuteDeleteAsync();
        return Ok();
    }
    /// <summary>
    /// Получить информацию о своём аккаунте
    /// </summary>
    [HttpPost("about"), Authorize(Policy = "User")]
    public async Task<IActionResult> AboutMe() 
    {
        return Ok(new 
        {
            Email = HttpContext.User.FindFirst(ClaimTypes.Email)!.Value,
            EmailConfirmed = HttpContext.User.FindFirst("EmailConfirmed")!.Value,
            Role = HttpContext.User.FindFirst(ClaimTypes.Role)!.Value
        });
    }

    /// <summary>
    /// Удалить свой аккаунт
    /// </summary>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAccount() 
    {
        return Ok();
    }
    /// <summary>
    /// Удаление всех истёкших refresh-токенов
    /// </summary>
    private async Task DeleteExpiredTokensAsync(User user)
    {
        await DbContext.RefreshTokens
            .Include(rt => rt.User)
            .Where(rt => rt.User.Id == user.Id && rt.Expires < DateTime.UtcNow)
            .ExecuteDeleteAsync();
    }
    /// <summary>
    /// Установка refresh-токена в куки и добавление в базу данных
    /// </summary>
    private async Task SetRefreshToken(RefreshToken refreshToken) 
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = refreshToken.Expires
        };
        Response.Cookies.Append("RefreshToken", refreshToken.Token.ToString(), cookieOptions);
        DbContext.RefreshTokens.Add(refreshToken);
        await DbContext.SaveChangesAsync();
    }
    /// <summary>
    /// Получение refresh-токена из куки
    /// </summary>
    private Guid GetRefreshToken()
    {
        if (Request.Cookies.TryGetValue("RefreshToken", out string? refreshTokenStr))
        {
            if (Guid.TryParse(refreshTokenStr, out Guid token))
            {
                return token;
            }
            else
            {
                //изменить потом обработку ошибок
                throw new Exception("Incorrect refresh token.");
            }
        }
        else
        {
            //изменить потом обработку ошибок
            throw new Exception("Where is your refresh token?");
        }
    }
}
