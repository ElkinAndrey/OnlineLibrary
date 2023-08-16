using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

public class CreatePublishingHouseDto
{
    [Required]
    public string Name { get; set; }
}
