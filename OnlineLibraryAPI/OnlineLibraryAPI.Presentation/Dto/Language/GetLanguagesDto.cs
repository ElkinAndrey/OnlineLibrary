using OnlineLibraryAPI.Presentation.Constants;
using OnlineLibraryAPI.Presentation.Dto.Language.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Данные для получения языков
    /// </summary>
    public partial record class GetLanguagesDto(
        string? Name,
        int Start,
        int Length
        ) : IGetLanguagesDto;
}
