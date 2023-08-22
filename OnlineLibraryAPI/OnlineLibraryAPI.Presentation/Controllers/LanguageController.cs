using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Author;
using OnlineLibraryAPI.Presentation.Dto.Language;

namespace OnlineLibraryAPI.Presentation.Controllers;

/// <summary>
/// Контроллер для работы с авторами
/// </summary>
[Route("api/languages")]
[ApiController]
public class LanguageController : ControllerBase
{
    /// <summary>
    /// Получить список языков
    /// </summary>
    [HttpPost("get")]
    public async Task<IActionResult> GetLanguages([FromBody] GetLanguagesDto record)
    {
        return Ok(new List<object>()
        {
            new
            {
                Id = "00000000-0000-0000-0000-676175725156",
                Name = "Русский",
                EnglishName = "Russian",
                Abbreviation = "RU"
            },
            new
            {
                Id = "00000000-0000-0000-0000-657849819657",
                Name = "English",
                EnglishName = "English",
                Abbreviation = "EN"
            },
            new
            {
                Id = "00000000-0000-0000-0000-565787564746",
                Name = "Український",
                EnglishName = "Ukrainian",
                Abbreviation = "UA"
            },
        });
    }

    /// <summary>
    /// Получить количество языков
    /// </summary>
    [HttpPost("count")]
    public async Task<IActionResult> GetLanguagesCount([FromBody] GetLanguagesCountDto record)
    {
        return Ok(32);
    }

    /// <summary>
    /// Получить информацию об языке по Guid
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(new
        {
            Id = "00000000-0000-0000-0000-676175725156",
            Name = "Русский",
            EnglishName = "Russian",
            Abbreviation = "RU"
        });
    }

    /// <summary>
    /// Создать новый язык
    /// </summary>
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateLanguageDto languageDto)
    {
        return Ok();
    }

    /// <summary>
    /// Обновить информацию об языке
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLanguageDto languageDto)
    {
        return Ok();
    }

    /// <summary>
    /// Удалить язык по Guid
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok();
    }
}
