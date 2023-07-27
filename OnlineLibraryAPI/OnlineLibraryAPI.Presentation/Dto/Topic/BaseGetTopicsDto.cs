namespace OnlineLibraryAPI.Presentation.Dto.Topic
{
    /// <summary>
    /// Базовые данные для получения информации о категориях
    /// </summary>
    abstract public class BaseGetTopicsDto : IGetNameDto
    {
        public string? Name { get; set; } = null;
    }
}
