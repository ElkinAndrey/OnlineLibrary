using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
