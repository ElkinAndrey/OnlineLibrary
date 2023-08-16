using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

public class UpdatePublishingHouseDto
{
    [Required]
    public string Name { get; set; }
}