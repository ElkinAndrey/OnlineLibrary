using OnlineLibraryAPI.Presentation.Dto.Book.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Параметры для получения количества книг
    /// </summary>
    public partial record class GetEditionLanguagesCountDto(
        int? YearMin,
        int? YearMax,
        int? NumberPagesMin,
        int? NumberPagesMax,
        int? NumberAdditionsNotesMin,
        int? NumberAdditionsNotesMax,
        int? NumberDownloadsMin,
        int? NumberDownloadsMax,
        bool MustHaveAllTopics,
        Guid? LanguageId,
        List<Guid>? Topics,
        bool MustHaveAllAuthors,
        List<Guid>? Authors,
        bool MustHaveAllPublishers,
        List<Guid>? Publishers,
        string? Name
        ) : IGetEditionLanguagesCountDto;
}
