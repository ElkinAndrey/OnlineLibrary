using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

public class PublishingHouseUpdateDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
}