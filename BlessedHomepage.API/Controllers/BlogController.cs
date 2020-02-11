using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlessedHomepage.API.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("posts")]
        public async Task<IActionResult> PostPost()
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost()
        {
            return Ok();
        }
    }
}