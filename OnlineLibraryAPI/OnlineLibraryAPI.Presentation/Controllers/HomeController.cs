using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Привет мир
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> HelloWorld()
        {
            return Ok("Привет мир");
        }
    }
}