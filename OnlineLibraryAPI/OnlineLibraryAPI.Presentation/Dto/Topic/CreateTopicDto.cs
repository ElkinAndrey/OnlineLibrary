using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Topic;

public class CreateTopicDto
{
    [Required]
    public string Name { get; set; } = null!;
}
