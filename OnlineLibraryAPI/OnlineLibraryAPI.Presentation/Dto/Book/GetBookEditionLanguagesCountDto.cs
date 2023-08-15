namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Данные для получения количества языков того же издания
    /// </summary>
    /// <remarks>
    /// string? Name - Часть названия,
    /// Guid? BookEditionLanguageId - Id издания книги на отдельном языке,
    /// </remarks>
    public class GetBookEditionLanguagesCountDto : BaseGetBookEditionLanguagesDto
    {
    }
}
