using OnlineLibraryAPI.Presentation.Constants;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Параметры для получения книг
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// string? Name - Часть названия книги,
    /// int? YearMin - Минимальный год издания,
    /// int? YearMax - Максимальный год издания,
    /// int? NumberPagesMin - Минимальное количество страниц,
    /// int? NumberPagesMax - Максимальное количество станиц,
    /// int? NumberAdditionsNotesMin - Минимальное количество добавления в заметки,
    /// int? NumberAdditionsNotesMax - Максимальное количество добавления в заметки,
    /// int? NumberDownloadsMin - Минимальное количество скачиваний,
    /// int? NumberDownloadsMax - Максимальное количество скачиваний,
    /// Guid? LanguageId - Id языка,
    /// bool MustHaveAllTopics - Должен ли иметь все введенные категории,
    /// List Guid? Topics - Категории,
    /// bool MustHaveAllAuthors - Должен ли иметь всех введенных авторов,
    /// List Guid? Authors - Авторы,
    /// bool MustHaveAllPublishers - Должен ли иметь все введенные издательства,
    /// List Guid? Publishers - Издательства,
    /// Guid? BookEditionId - Id издания книги,
    /// </remarks>
    public class GetBooksDto : BaseGetBooksDto, IGetCutDto
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = ConstantsForDto.DefaultCutLength;
    }
}
