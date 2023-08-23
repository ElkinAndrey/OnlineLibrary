using OnlineLibraryAPI.Presentation.Dto.Book.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Данные для получения количества языков того же издания
    /// </summary>
    public partial record class GetOtherEditionLanguagesCountDto(
        string? Name
        ) : IGetOtherEditionLanguagesCountDto;
}
