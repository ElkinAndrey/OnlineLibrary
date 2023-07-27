namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Параметры для получения количества книг
    /// </summary>
    /// <remarks>
    /// string? Name - Часть названия книги,
    /// int? YearMin - Минимальный год издания,
    /// int? YearMax - Максимальный год издания,
    /// int? NumberPagesMin - Минимальное количество страниц,
    /// int? NumberPagesMax - Максимальное количество станиц,
    /// int? NumberAdditionsNotesMin - Минимальное количество добавления в заметки,
    /// int? NumberAdditionsNotesMax - Максимальное количество добавления в заметки,
    /// bool MustHaveAllTopics - Должен ли иметь все введенные категории,
    /// Guid? LanguageId - Id языка,
    /// List Guid? Topics - Категории,
    /// bool MustHaveAllAuthors - Должен ли иметь всех введенных авторов,
    /// List Guid? Authors - Авторы,
    /// bool MustHaveAllPublishers - Должен ли иметь все введенные издательства,
    /// List Guid? Publishers - Издательства,
    /// Guid? BookEditionId - Id издания книги,
    /// </remarks>
    public class GetBooksCountDto : BaseGetBooksDto
    {
    }
}
