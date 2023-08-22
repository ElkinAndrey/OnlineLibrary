using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Author;

namespace OnlineLibraryAPI.Presentation.Controllers;

/// <summary>
/// Контроллер для работы с авторами
/// </summary>
[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    /// <summary>
    /// Получить список авторов
    /// </summary>
    [HttpPost("get")]
    public async Task<IActionResult> GetAuthors([FromBody] GetAuthorsDto record)
    {
        return Ok(new List<object>()
        {
            new
            {
                Id = new Guid("00000000-0000-0000-0000-456780127459"),
                Name = "Григорий Перельман",
            },
            new
            {
                Id = new Guid("00000000-0000-0000-0000-072581860716"),
                Name = "Бьерн Страуструп",
            },
            new
            {
                Id = new Guid("00000000-0000-0000-0000-762356361361"),
                Name = "Дональд Кнуд",
            },
        });
    }

    /// <summary>
    /// Получить информацию об авторе по Guid
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id) 
    {
        return Ok(new
        {
            Id = new Guid("00000000-0000-0000-0000-456780127459"),
            Name = "Григорий Перельман",
        });
    }

    /// <summary>
    /// Создать нового автора
    /// </summary>
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateAuthorDto authorDto) 
    {
        return Ok();
    }

    /// <summary>
    /// Обновить информацию об авторе
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAuthorDto authorDto) 
    {
        return Ok();
    }

    /// <summary>
    /// Удалить автора по Guid
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id) 
    {
        return Ok();
    }

    /// <summary>
    /// Получить количество авторов
    /// </summary>
    [HttpPost("count")]
    public async Task<IActionResult> GetAuthorsCount([FromBody] GetAuthorsCountDto record)
    {
        return Ok(56);
    }
}
