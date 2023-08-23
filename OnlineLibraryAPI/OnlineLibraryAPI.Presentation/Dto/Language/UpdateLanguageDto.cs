using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Language;

/// <summary>
/// Данные для изменения языка
/// </summary>
public class UpdateLanguageDto
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
