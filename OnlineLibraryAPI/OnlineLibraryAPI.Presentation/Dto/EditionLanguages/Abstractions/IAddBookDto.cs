using Microsoft.AspNetCore.Http;

namespace OnlineLibraryAPI.Presentation.Dto.EditionLanguages.Abstractions
{
    /// <summary>
    /// Параметры для добавления книги
    /// </summary>
    public interface IAddBookDto
    {
        /// <summary>
        /// Название
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Описание всей книги
        /// </summary>
        string? GeneralDescription { get; }

        /// <summary>
        /// Год издания
        /// </summary>
        int? Year { get; }

        /// <summary>
        /// Описание конкретного издания
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// Номер издания
        /// </summary>
        string? EditionNumber { get; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        int? NumberPages { get; }

        /// <summary>
        /// Категории
        /// </summary>
        List<Guid>? Topics { get; }

        /// <summary>
        /// Авторы
        /// </summary>
        List<Guid>? Authors { get; }

        /// <summary>
        /// Издательства
        /// </summary>
        List<Guid>? Publishers { get; }

        /// <summary>
        /// Язык
        /// </summary>
        Guid? Language { get; }

        /// <summary>
        /// Расширение файла для скачивания
        /// </summary>
        Guid? FileExtensions { get; }

        /// <summary>
        /// Обложка
        /// </summary>
        IFormFile? Cover { get; }

        /// <summary>
        /// Файл для скачивания
        /// </summary>
        IFormFile? File { get; }
    }
}
