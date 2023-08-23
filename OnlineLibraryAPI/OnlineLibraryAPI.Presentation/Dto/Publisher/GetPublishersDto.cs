using OnlineLibraryAPI.Presentation.Constants;
using OnlineLibraryAPI.Presentation.Dto.Publisher.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse
{
    /// <summary>
    /// Парметры для получения издательств
    /// </summary>
    public partial record class GetPublishersDto (
        string? Name,
        int Start,
        int Length
        ) : IGetPublishersDto;
}
