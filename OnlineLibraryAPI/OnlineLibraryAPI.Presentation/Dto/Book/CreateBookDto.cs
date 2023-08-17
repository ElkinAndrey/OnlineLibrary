using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryAPI.Presentation.Dto.Book;

public class CreateBookDto
{
    /// <summary>
    /// заголовок
    /// </summary>
    [Required]
    public string Title { get; set; } = null!;
    /// <summary>
    /// описание
    /// </summary>
    [Required]
    public string Description { get; set; } = null!;
    /// <summary>
    /// Id языка
    /// </summary>
    [Required]
    public Guid LanguageId { get; set; }
    /// <summary>
    /// Id издательства
    /// </summary>
    [Required]
    public Guid PublisherHouseId { get; set; }
    /// <summary>
    /// Год издания
    /// </summary>
    [Required]
    public int Year { get; set; }
    /// <summary>
    /// Категории
    /// </summary>
    [Required]
    public List<Guid> Topics { get; set; } = null!;
    /// <summary>
    /// Кол-во страниц
    /// </summary>
    [Required]
    public int NumberPages { get; set; }
}
