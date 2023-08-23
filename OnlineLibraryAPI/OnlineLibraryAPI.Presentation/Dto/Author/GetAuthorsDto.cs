using OnlineLibraryAPI.Presentation.Constants;
using OnlineLibraryAPI.Presentation.Dto.Author.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Author
{
    /// <summary>
    /// Данные для получения авторов
    /// </summary>
    public partial record class GetAuthorsDto(
        string? Name,
        int Start,
        int Length
        ) : IGetAuthorsDto;
}
