using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AngularDotnetCore.Data;
using AngularDotnetCore.Dto;
using AngularDotnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotnetCore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public PostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Post([FromBody] PostDto dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                Post model = new Post { 
                    OwnerId = userId,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Title = dto.Title,
                    Content = dto.Content,
                    City = dto.City,
                    PostalCode = dto.PostalCode,
                    ContactEmail = dto.ContactEmail,
                    ContactPhone = dto.ContactPhone
                };
                _context.Posts.Add(model);
                
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