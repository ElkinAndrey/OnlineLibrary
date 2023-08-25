using OnlineLibraryAPI.Presentation.Dto.FileExtension.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.FileExtension
{
    /// <summary>
    /// Параметры для получения количества расширений файлов
    /// </summary>
    public partial record class GetFileExtensionsCountDto(
        string? Name
        ) : IGetFileExtensionsCountDto;
}
