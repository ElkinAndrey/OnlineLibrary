using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Topic;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с темами книг
    /// </summary>
    [Route("api/topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        /// <summary>
        /// Получить список категорий книг
        /// </summary>
        [HttpPost("get")]
        public async Task<IActionResult> GetTopics([FromBody] GetTopicsDto record)
        {
            return Ok(new List<object>()
            {
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-742948371949"),
                    Name = "Программирование",
                },
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-967717386958"),
                    Name = "Математика",
                },
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-715125715760"),
                    Name = "Алгоритмы",
                },
            });
        }
        /// <summary>
        /// Получить категорию по guid
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            return Ok(new
            {
                Id = new Guid("00000000-0000-0000-0000-715125715760"),
                Name = "Алгоритмы",
            });
        }
        /// <summary>
        /// Получить количество книг в категории
        /// </summary>
        [HttpPost("count")]
        public async Task<IActionResult> GetTopicsCount([FromBody] GetTopicsCountDto record)
        {
            return Ok(145);
        }
        /// <summary>
        /// Создать категорию
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateTopicDto record)
        {
            return Ok();
        }
        /// <summary>
        /// Обновить категорию
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTopicDto record)
        {
            return Ok();
        }
        /// <summary>
        /// Удалить категорию
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
