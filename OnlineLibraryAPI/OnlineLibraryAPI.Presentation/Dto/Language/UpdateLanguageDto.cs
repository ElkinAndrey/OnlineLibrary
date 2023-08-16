using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Language;

public class UpdateLanguageDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string EnglishName { get; set; }
    [Required]
    public string Abbreviation { get; set; }
}
