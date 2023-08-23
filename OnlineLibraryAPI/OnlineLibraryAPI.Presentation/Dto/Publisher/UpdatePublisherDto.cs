using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

/// <summary>
/// Параметры для изменения издательства
/// </summary>
public class UpdatePublisherDto
{

    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }
}