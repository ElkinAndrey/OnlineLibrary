using OnlineLibraryAPI.Presentation.Constants;

namespace OnlineLibraryAPI.Presentation.Dto.Book
{
    /// <summary>
    /// Данные для получения списка языков того же издания книги
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// string? Name - Часть названия,
    /// Guid? BookEditionLanguageId - Id издания книги на отдельном языке,
    /// </remarks>
    public class GetBookEditionLanguagesDto : BaseGetBookEditionLanguagesDto, IGetCutDto
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = ConstantsForDto.DefaultCutLength;
    }
}
