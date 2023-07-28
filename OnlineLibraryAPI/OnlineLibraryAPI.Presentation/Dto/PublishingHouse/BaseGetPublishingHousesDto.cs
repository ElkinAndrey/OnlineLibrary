namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse
{
    /// <summary>
    /// Базовые данные для получения информации об издательствах
    /// </summary>
    abstract public class BaseGetAuthorsDto : IGetNameDto
    {
        public string? Name { get; set; } = null;
    }
}
