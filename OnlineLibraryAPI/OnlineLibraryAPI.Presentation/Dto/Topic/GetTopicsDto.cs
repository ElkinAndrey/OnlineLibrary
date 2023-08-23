using OnlineLibraryAPI.Presentation.Dto.Topic.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Topic
{
    /// <summary>
    /// Параметры для получения категорий
    /// </summary>
    public partial record class GetTopicsDto(
        string? Name,
        int Start,
        int Length
        ) : IGetTopicsDto;
}
