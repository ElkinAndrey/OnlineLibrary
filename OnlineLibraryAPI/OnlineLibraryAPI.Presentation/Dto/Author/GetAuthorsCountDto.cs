using OnlineLibraryAPI.Presentation.Dto.Author.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Author
{
    /// <summary>
    /// Данные для получения количества авторов
    /// </summary>
    public partial record class GetAuthorsCountDto(
        string? Name
        ) : IGetAuthorsCountDto;
}
