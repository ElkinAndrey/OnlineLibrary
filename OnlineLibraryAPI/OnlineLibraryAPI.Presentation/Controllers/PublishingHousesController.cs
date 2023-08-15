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
    public class PublishingHousesController : ControllerBase
    {
        /// <summary>
        /// Получить список издательств
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetPublishingHouses([FromBody] GetPublishingHousesDto record)
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
        [HttpPost]
        [Route("count")]
        public async Task<IActionResult> GetPublishingHousesCount([FromBody] GetPublishingHousesCountDto record)
        {
            return Ok(56);
        }
        /// <summary>
        /// Получить информацию о издательстве по Guid
        /// </summary>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PublishingHouseCreateDto publishingHouseDto)
        {
            return Ok();
        }
        /// <summary>
        /// Обновить информацию о издательстве
        /// </summary>
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] PublishingHouseUpdateDto publishingHouseDto)
        {
            return Ok();
        }
        /// <summary>
        /// Удалить издательство по Guid
        /// </summary>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }
    }
}
