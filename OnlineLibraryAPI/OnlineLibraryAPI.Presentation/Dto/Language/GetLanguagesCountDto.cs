namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Данные для получения количества языков
    /// </summary>
    /// <remarks>
    /// string? Name - Часть названия,
    /// Guid? BookEditionId - Id издания книги, у которого нужно искать язык
    /// </remarks>
    public class GetLanguagesCountDto : BaseGetLanguagesDto
    {
    }
}
