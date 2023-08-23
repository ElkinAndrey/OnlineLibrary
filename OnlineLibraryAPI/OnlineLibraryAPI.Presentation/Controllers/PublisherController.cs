using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Author;
using OnlineLibraryAPI.Presentation.Dto.PublishingHouse;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с издательствами
    /// </summary>
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        /// <summary>
        /// Получить список издательств
        /// </summary>
        [HttpPost("get")]
        public async Task<IActionResult> GetPublishingHouses([FromBody] GetPublishersDto record)
        {
            return Ok(new List<object>()
            {
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-173576375615"),
                    Name = "БХВ-Петербург",
                },
                new
                {
                    Id = new Guid("00000000-0000-0000-0000-798164716678"),
                    Name = "ООО Издательство «Питер»",
                },
            });
        }

        /// <summary>
        /// Получить количество издательств
        /// </summary>
        [HttpPost("count")]
        public async Task<IActionResult> GetPublishingHousesCount([FromBody] GetPublishersCountDto record)
        {
            return Ok(56);
        }

        /// <summary>
        /// Получить информацию о издательстве по Guid
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(
               new
               {
                   Id = new Guid("00000000-0000-0000-0000-798164716678"),
                   Name = "ООО Издательство «Питер»"
               }
            );
        }

        /// <summary>
        /// Создать новое издательство
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreatePublisherDto publishingHouseDto)
        {
            return Ok();
        }

        /// <summary>
        /// Обновить информацию о издательстве
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePublisherDto publishingHouseDto)
        {
            return Ok();
        }

        /// <summary>
        /// Удалить издательство по Guid
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
