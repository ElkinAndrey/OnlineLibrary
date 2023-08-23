namespace OnlineLibraryAPI.Presentation.Dto
{
    /// <summary>
    /// Интерфейс Dto для получения среза
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// </remarks>
    public interface IGetCutDto
    {
        /// <summary>
        /// Начало отчета
        /// </summary>
        int Start { get; }

        /// <summary>
        /// Длина среза
        /// </summary>
        int Length { get; }
    }
}
