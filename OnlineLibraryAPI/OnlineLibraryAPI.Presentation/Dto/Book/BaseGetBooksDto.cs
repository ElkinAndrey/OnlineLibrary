namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Базовые параметры для получения информации о книгах
    /// </summary>    
    /// <remarks>
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
    abstract public class BaseGetBooksDto : IGetNameDto
    {
        public string? Name { get; set; }

        /// <summary>
        /// Минимальный год издания
        /// </summary>
        public int? YearMin { get; set; }

        /// <summary>
        /// Максимальный год издания
        /// </summary>
        public int? YearMax { get; set; }

        /// <summary>
        /// Минимальное количество страниц
        /// </summary>
        public int? NumberPagesMin { get; set; }

        /// <summary>
        /// Максимальное количество станиц
        /// </summary>
        public int? NumberPagesMax { get; set; }

        /// <summary>
        /// Минимальное количество добавления в заметки
        /// </summary>
        public int? NumberAdditionsNotesMin { get; set; }

        /// <summary>
        /// Максимальное количество добавления в заметки
        /// </summary>
        public int? NumberAdditionsNotesMax { get; set; }

        /// <summary>
        /// Минимальное количество скачиваний
        /// </summary>
        public int? NumberDownloadsMin { get; set; }

        /// <summary>
        /// Максимальное количество скачиваний
        /// </summary>
        public int? NumberDownloadsMax { get; set; }

        /// <summary>
        /// Должен ли иметь все введенные категории
        /// </summary>
        public bool MustHaveAllTopics { get; set; }

        /// <summary>
        /// Id языка
        /// </summary>
        public Guid? LanguageId { get; set; }

        /// <summary>
        /// Категории
        /// </summary>
        public List<Guid>? Topics { get; set; }

        /// <summary>
        /// Должен ли иметь всех введенных авторов
        /// </summary>
        public bool MustHaveAllAuthors { get; set; }
        /// <summary>
        /// Авторы
        /// 
        public List<Guid>? Authors { get; set; }

        /// <summary>
        /// Должен ли иметь все введенные издательства
        /// </summary>
        public bool MustHaveAllPublishers { get; set; }

        /// <summary>
        /// Издательства
        /// </summary>
        public List<Guid>? Publishers { get; set; }

        /// <summary>
        /// Id издания книги
        /// </summary>
        public Guid? BookEditionId { get; set; }
    }
}
