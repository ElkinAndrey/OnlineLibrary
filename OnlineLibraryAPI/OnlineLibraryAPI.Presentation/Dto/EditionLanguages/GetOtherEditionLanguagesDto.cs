using OnlineLibraryAPI.Presentation.Constants;
using OnlineLibraryAPI.Presentation.Dto.Book.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Праметры для получения других языков издания
    /// </summary>
    public partial record class GetOtherEditionLanguagesDto (
        string? Name,
        int Start,
        int Length
        ) : IGetOtherEditionLanguagesDto;
}
