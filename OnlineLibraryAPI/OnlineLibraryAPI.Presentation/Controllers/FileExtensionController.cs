using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.FileExtension;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с расширениями файлов
    /// </summary>
    [Route("api/file")]
    [ApiController]
    public class FileExtensionController : ControllerBase
    {
        /// <summary>
        /// Получить список расширений файлов
        /// </summary>
        [HttpPost("get")]
        public async Task<IActionResult> GetFileExtensions(GetFileExtensionsDto model)
        {
            return Ok(new List<object>()
            {
                new
                {
                    Id = "00000000-0000-0000-0000-781238577832",
                    Name = "pdf",
                },
                new
                {
                    Id = "00000000-0000-0000-0000-098812589125",
                    Name = "fb2",
                },
                new
                {
                    Id = "00000000-0000-0000-0000-019928589125",
                    Name = "epub",
                },
                new
                {
                    Id = "00000000-0000-0000-0000-908167457715",
                    Name = "djvu",
                },
            });
        }

        /// <summary>
        /// Получить количество расширений файлов
        /// </summary>
        [HttpPost("count")]
        public async Task<IActionResult> GetFileExtensionsCount(GetFileExtensionsCountDto model)
        {
            return Ok(13);
        }
    }
}
