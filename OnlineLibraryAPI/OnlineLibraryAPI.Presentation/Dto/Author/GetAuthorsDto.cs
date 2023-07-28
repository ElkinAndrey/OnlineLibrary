using OnlineLibraryAPI.Presentation.Constants;

namespace OnlineLibraryAPI.Presentation.Dto.Author
{
    /// <summary>
    /// Данные для получения списка авторов
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// string? Name - Часть названия,
    /// </remarks>
    public class GetAuthorsDto : BaseGetAuthorsDto, IGetCutDto
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = ConstantsForDto.DefaultCutLength;
    }
}
