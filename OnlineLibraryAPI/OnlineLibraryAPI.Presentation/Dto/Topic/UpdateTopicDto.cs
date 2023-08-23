using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Topic;

/// <summary>
/// Параметры для изменения категории
/// </summary>
public class UpdateTopicDto
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;
}
