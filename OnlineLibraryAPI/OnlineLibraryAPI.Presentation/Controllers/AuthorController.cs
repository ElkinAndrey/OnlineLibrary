using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Author;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с авторами
    /// </summary>
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// Получить список авторов
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetAuthors([FromBody] GetAuthorsDto record)
        {
            return Ok(new List<object>()
            {
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-456780127459"),
                    Name = "Григорий Перельман",
                },
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-072581860716"),
                    Name = "Бьерн Страуструп",
                },
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-762356361361"),
                    Name = "Дональд Кнуд",
                },
            });
        }

        /// <summary>
        /// Получить количество авторов
        /// </summary>
        [HttpPost]
        [Route("count")]
        public async Task<IActionResult> GetAuthorsCount([FromBody] GetAuthorsCountDto record)
        {
            return Ok(56);
        }
    }
}
