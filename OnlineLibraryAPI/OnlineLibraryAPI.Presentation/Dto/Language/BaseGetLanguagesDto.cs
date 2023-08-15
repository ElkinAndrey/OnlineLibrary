namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Базовые данные для получения информации об языках
    /// </summary>
    abstract public class BaseGetLanguagesDto : IGetNameDto
    {
        public string? Name { get; set; } = null;        
    }
}
