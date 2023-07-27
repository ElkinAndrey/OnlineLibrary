using OnlineLibraryAPI.Presentation.Constants;

namespace OnlineLibraryAPI.Presentation.Dto.Topic
{
    /// <summary>
    /// Данные для получения списка категорий
    /// </summary>
    /// <remarks>
    /// int Start - Начало отчета,
    /// int Length - Длина среза,
    /// string? Name - Часть названия категории,
    /// </remarks>
    public class GetTopicsDto : BaseGetTopicsDto, IGetCutDto
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = ConstantsForDto.DefaultCutLength;
    }
}
