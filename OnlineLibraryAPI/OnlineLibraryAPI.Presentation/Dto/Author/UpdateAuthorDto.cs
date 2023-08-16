using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Author;

public class UpdateAuthorDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
}
