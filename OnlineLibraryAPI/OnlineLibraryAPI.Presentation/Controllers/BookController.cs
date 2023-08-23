﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Добавление новой книги
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddBook()
        {
            return Ok();
        }
    }
}
