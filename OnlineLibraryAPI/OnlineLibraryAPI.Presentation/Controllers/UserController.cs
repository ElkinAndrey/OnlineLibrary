using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Получить кол-во пользователей
        /// </summary>
        [HttpPost("count")]
        public async Task<IActionResult> Count() 
        {
            return Ok(30);
        }
    }
}
