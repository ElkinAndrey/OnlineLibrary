using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Topic;

public class UpdateTopicDto
{
    [Required]
    public string Name { get; set; } = null!;
}
