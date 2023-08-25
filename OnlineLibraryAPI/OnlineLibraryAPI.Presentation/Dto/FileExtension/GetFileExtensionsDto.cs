using OnlineLibraryAPI.Presentation.Dto.FileExtension.Abstractions;

namespace OnlineLibraryAPI.Presentation.Dto.FileExtension
{
    /// <summary>
    /// Параметры для получения расширений файлов
    /// </summary>
    public partial record class GetFileExtensionsDto(
        string? Name,
        int Start,
        int Length
        ) : IGetFileExtensionsDto;
}
