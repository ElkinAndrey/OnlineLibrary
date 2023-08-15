using OnlineLibraryAPI.Presentation.Dto.Language;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Базовые данные для получения информации об языках издания книги
    /// </summary>
    abstract public class BaseGetBookEditionLanguagesDto : IGetNameDto
    {
        public string? Name { get; set; } = null;

        /// <summary>
        /// Id издания книги на отдельном языке
        /// </summary>
        public Guid? BookEditionLanguageId { get; set; } = null;
    }
}
