using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.EditionLanguages;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с книгами
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Добавление новой книги
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromForm] AddBookDto model)
        {
            return Ok();
        }
    }
}
