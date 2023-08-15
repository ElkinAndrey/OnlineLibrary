using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Auth;

namespace OnlineLibraryAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
    {
        return Ok();
    }
    /// <summary>
    /// Войти (получить access- и refresh- токены)
    /// </summary>
    [HttpPost("Login")]
    public async Task<IActionResult> LoginDto([FromBody] LoginDto loginDto) 
    {
        return Ok(1);
    }
    /// <summary>
    /// Выйти из аккаунта (удалить refresh-токен)
    /// </summary>
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout() 
    {
        return Ok();
    }
    /// <summary>
    /// Получить информацию о своём аккаунте
    /// </summary>
    [HttpPost("AboutMe")]
    public async Task<IActionResult> AboutMe() 
    {
        return Ok(
            new
            {
                Email = "ivan@mail.ru"
            }
        );
    }
}
