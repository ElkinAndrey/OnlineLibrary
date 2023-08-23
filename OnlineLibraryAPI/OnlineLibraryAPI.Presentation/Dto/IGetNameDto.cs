namespace OnlineLibraryAPI.Presentation.Dto
{
    /// <summary>
    /// Интерфейс Dto для получения части названия
    /// </summary>
    /// <remarks>
    /// string? Name - Часть названия,
    /// </remarks>
    public interface IGetNameDto
    {
        /// <summary>
        /// Часть названия
        /// </summary>
        string? Name { get; }
    }
}
