namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Базовые данные для получения информации об языках
    /// </summary>
    abstract public class BaseGetLanguagesDto : IGetNameDto
    {
        public string? Name { get; set; } = null;

        /// <summary>
        /// Id издания книги, у которого нужно искать язык
        /// </summary>
        public Guid? BookEditionId { get; set; } = null;
        
    }
}
