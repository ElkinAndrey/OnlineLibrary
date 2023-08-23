using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Author;

/// <summary>
/// Данные для изменнения автора
/// </summary>
public class UpdateAuthorDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string Name { get; set; }
}
