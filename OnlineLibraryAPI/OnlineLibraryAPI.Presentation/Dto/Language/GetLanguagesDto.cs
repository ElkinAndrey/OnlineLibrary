using OnlineLibraryAPI.Presentation.Constants;

namespace OnlineLibraryAPI.Presentation.Dto.Language
{
    /// <summary>
    /// Данные для получения списка языков
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// string? Name - Часть названия,
    /// </remarks>
    public class GetLanguagesDto : BaseGetLanguagesDto, IGetCutDto
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = ConstantsForDto.DefaultCutLength;
    }
}
