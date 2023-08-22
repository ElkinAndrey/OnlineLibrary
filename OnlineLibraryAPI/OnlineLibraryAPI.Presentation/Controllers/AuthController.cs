using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Auth;

namespace OnlineLibraryAPI.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
    {
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
