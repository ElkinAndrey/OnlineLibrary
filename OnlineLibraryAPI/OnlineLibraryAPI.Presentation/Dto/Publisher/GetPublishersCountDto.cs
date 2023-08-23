using OnlineLibraryAPI.Presentation.Dto.Publisher.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.PublishingHouse
{
    /// <summary>
    /// Парметры для получения количества издательств
    /// </summary>
    public partial record class GetPublishersCountDto(
        string? Name
        ) : IGetPublishersCountDto;
}
