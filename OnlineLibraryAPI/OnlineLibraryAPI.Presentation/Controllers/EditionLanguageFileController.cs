using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    [Route("api/books/editions/languages/files")]
    [ApiController]
    public class EditionLanguageFileController : ControllerBase
    {
        /// <summary>
        /// Скачать файл книги по Id
        /// </summary>
        [HttpGet("{editionLanguageFileId}/download")]
        public async Task<IActionResult> GetBookFileByEditionLanguageFileId(Guid editionLanguageFileId)
        {
            Stream stream = new FileStream("HelpFiles\\Book.pdf", FileMode.Open);
            string mimeType = "application/pdf";
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "Book.pdf"
            };
        }

        /// <summary>
        /// Добавление расширения файла к уже существующему языку
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddEditionLanguageFile()
        {
            return Ok();
        }
    }
}
