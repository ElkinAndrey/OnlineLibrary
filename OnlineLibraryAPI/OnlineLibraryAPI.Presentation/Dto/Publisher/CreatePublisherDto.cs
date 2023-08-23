using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

/// <summary>
/// Параметры для создания издательства
/// </summary>
public class CreatePublisherDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }
}
