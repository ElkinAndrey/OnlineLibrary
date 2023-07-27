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
        public int Start { get; set; }

        /// <summary>
        /// Длина среза
        /// </summary>
        public int Length { get; set; }
    }
}
