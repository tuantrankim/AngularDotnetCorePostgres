using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotnetCore.Data;
using AngularDotnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotnetCore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allPosts = _context.Posts.ToList();
                return Ok(allPosts);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get posts");
            }
        }

        //GET: api/posts/id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var post = _context.Posts
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
                if (post != null) return Ok(post);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get a post");
            }
        }

        //POST: api/posts
        //model is come from body
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Post model)
        {
            try
            {
                _context.Add(model);
                if (_context.SaveChanges() > 0)
                {
                    //instead of return 200: Ok, we return 201: Created 
                    return Created($"/api/posts/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Failed to save new user: {ex}");
            }

            return BadRequest("Failed to save a new post");
        }
    }
}