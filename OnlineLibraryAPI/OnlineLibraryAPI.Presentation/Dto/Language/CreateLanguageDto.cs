using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Language;

/// <summary>
/// Данные для создания языка
/// </summary>
public class CreateLanguageDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Название на английском
    /// </summary>
    [Required]
    public string EnglishName { get; set; }

    /// <summary>
    /// Сокращенное название
    /// </summary>
    [Required]
    public string Abbreviation { get; set; }
}
