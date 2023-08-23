using OnlineLibraryAPI.Presentation.Dto.Topic.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.Topic
{
    /// <summary>
    /// Параметры для получения количества категорий
    /// </summary>
    public partial record class GetTopicsCountDto(
        string? Name
        ) : IGetTopicsCountDto;
}
