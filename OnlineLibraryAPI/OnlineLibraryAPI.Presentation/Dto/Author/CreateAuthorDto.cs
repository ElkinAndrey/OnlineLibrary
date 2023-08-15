using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Author;

public class CreateAuthorDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
}
