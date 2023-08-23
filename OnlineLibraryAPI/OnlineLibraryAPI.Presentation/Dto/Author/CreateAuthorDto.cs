using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Author;

/// <summary>
/// Данные для создания автора
/// </summary>
public class CreateAuthorDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string Name { get; set; }
}
