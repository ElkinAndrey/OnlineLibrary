using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

public class PublishingHouseCreateDto
{
    [Required]
    public string Name { get; set; }
}
