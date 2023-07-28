namespace OnlineLibraryAPI.Presentation.Dto.Author
{
    /// <summary>
    /// Базовые данные для получения информации об авторах
    /// </summary>
    abstract public class BaseGetAuthorsDto : IGetNameDto
    {
        public string? Name { get; set; } = null;
    }
}
