using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlessedHomepage.API.Common.Repositories;
using BlessedHomepage.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlessedHomepage.API.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _blogRepository.GetAllBlogPostsAsync();
            return Ok(posts);
        }

        [Authorize]
        [HttpPost("posts")]
        public async Task<IActionResult> PostPost(BlogPost post)
        {
            await _blogRepository.AddBlogPostAsync(post);
            return Ok();
        }

        [Authorize]
        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            await _blogRepository.DeleteBlogPostAsync(id);
            return Ok();
        }
    }
}