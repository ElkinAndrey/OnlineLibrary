using OnlineLibraryAPI.Presentation.Dto.Language.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Данные для получения количества языков
    /// </summary>
    public partial record class GetLanguagesCountDto(
        string? Name
        ) : IGetLanguagesCountDto;
}
