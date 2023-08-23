using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Topic;

/// <summary>
/// Параметры для создания категории
/// </summary>
public class CreateTopicDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;
}
