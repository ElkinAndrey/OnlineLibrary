using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    [Route("api/books/editions")]
    [ApiController]
    public class EditionController : ControllerBase
    {
        /// <summary>
        /// Добавление издания к уже существующей книге
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddEdition()
        {
            return Ok();
        }
    }
}
