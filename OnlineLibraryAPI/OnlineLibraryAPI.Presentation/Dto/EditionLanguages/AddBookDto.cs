using OnlineLibraryAPI.Presentation.Dto.EditionLanguages.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.EditionLanguages
{
    /// <summary>
    /// Параметры для добавления книги
    /// </summary>
    public partial record class AddBookDto(
        string? Name,
        string? GeneralDescription,
        int? Year,
        string? Description,
        string? EditionNumber,
        int? NumberPages,
        List<Guid>? Topics,
        List<Guid>? Authors,
        List<Guid>? Publishers,
        Guid? Language,
        Guid? FileExtensions,
        IFormFile? Cover,
        IFormFile? File
        ) : IAddBookDto;
}
