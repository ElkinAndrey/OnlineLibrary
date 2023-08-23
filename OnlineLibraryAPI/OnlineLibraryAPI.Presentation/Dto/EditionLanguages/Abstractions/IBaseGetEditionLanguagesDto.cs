namespace OnlineLibraryAPI.Presentation.Dto.Book.Abstractions
{
    /// <summary>
    /// Базовые параметры для получения информации о книгах
    /// </summary>    
    public interface IBaseGetEditionLanguagesDto : IGetNameDto
    {
        /// <summary>
        /// Минимальный год издания
        /// </summary>
        int? YearMin { get; }

        /// <summary>
        /// Максимальный год издания
        /// </summary>
        int? YearMax { get; }

        /// <summary>
        /// Минимальное количество страниц
        /// </summary>
        int? NumberPagesMin { get; }

        /// <summary>
        /// Максимальное количество станиц
        /// </summary>
        int? NumberPagesMax { get; }

        /// <summary>
        /// Минимальное количество добавления в заметки
        /// </summary>
        int? NumberAdditionsNotesMin { get; }

        /// <summary>
        /// Максимальное количество добавления в заметки
        /// </summary>
        int? NumberAdditionsNotesMax { get; }

        /// <summary>
        /// Минимальное количество скачиваний
        /// </summary>
        int? NumberDownloadsMin { get; }

        /// <summary>
        /// Максимальное количество скачиваний
        /// </summary>
        int? NumberDownloadsMax { get; }

        /// <summary>
        /// Должен ли иметь все введенные категории
        /// </summary>
        bool MustHaveAllTopics { get; }

        /// <summary>
        /// Id языка
        /// </summary>
        Guid? LanguageId { get; }

        /// <summary>
        /// Категории
        /// </summary>
        List<Guid>? Topics { get; }

        /// <summary>
        /// Должен ли иметь всех введенных авторов
        /// </summary>
        bool MustHaveAllAuthors { get; }
        /// <summary>
        /// Авторы
        /// 
        List<Guid>? Authors { get; }

        /// <summary>
        /// Должен ли иметь все введенные издательства
        /// </summary>
        bool MustHaveAllPublishers { get; }

        /// <summary>
        /// Издательства
        /// </summary>
        List<Guid>? Publishers { get; }
    }
}
