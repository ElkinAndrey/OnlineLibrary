using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Domain.Constants;
using OnlineLibraryAPI.Domain.Entities;
using OnlineLibraryAPI.Presentation.Dto.Auth;
using OnlineLibraryAPI.Services.Abstractions;
using OnlineLibraryAPI.Services.Persistence;

namespace OnlineLibraryAPI.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private AppDbContext DbContext { get; set; }
    private IPasswordService PasswordService { get; set; }
    private IEmailService EmailService { get; set; }
    public AuthController(AppDbContext dbContext, IPasswordService passwordService, IEmailService emailService)
    {
        DbContext = dbContext;
        PasswordService = passwordService;
        EmailService = emailService;
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
    {
        if (await EmailService.IsExistingEmailAsync(registerDto.Email))
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
    public async Task<IActionResult> LoginDto([FromBody] LoginDto loginDto) 
    {
        return Ok(1);
    }

    /// <summary>
    /// Выйти из аккаунта (удалить refresh-токен)
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout() 
    {
        return Ok();
    }

    /// <summary>
    /// Получить информацию о своём аккаунте
    /// </summary>
    [HttpPost("about")]
    public async Task<IActionResult> AboutMe() 
    {
        return Ok(
            new
            {
                Email = "ivan@mail.ru"
            }
        );
    }

    /// <summary>
    /// Удалить свой аккаунт
    /// </summary>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAccount() 
    {
        return Ok();
    }
}
