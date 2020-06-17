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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AngularDotnetCore.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PostsController> _logger;
        public PostsController(ILogger<PostsController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        // GET: api/posts/getlatest
        [HttpGet]
        public IActionResult GetLatest()
        {
            try
            {
                var allPosts = _context.Posts
                    .Include(p => p.City)
                    .ThenInclude(c => c.State)
                    .OrderByDescending(x=>x.CreatedDate)
                    .Select(p => new PostDto()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = "",

                        CityId = p.CityId,
                        City = p.City.Name + ", " + p.City.State.Abbreviation,
                        CategoryId = p.CategoryId,
                        Category = p.Category.Name,

                        PostalCode = p.PostalCode,
                        ContactEmail = p.ContactEmail,
                        ContactPhone = p.ContactPhone,
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate
                    })
                    .Take(30).ToList();
                return Ok(allPosts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logger.LogTrace(ex, ex.Message);
                return BadRequest("Failed to get posts");
            }
        }

        [HttpPost]
        // POST: api/posts/SearchLatest
        public IActionResult SearchLatest([FromBody] PostSearchCriteriaDto dto)
        {
            try
            {
                IQueryable<Post> query = _context.Posts
                    .Include(p=>p.City)
                    .ThenInclude(c => c.State);

                if ((dto.FromPostId??0) > 0)
                {
                    query = query.Where(x => x.Id < dto.FromPostId);
                }

                if ((dto.CityId?? 0) > 0)
                {
                    query = query.Where(x => x.CityId == dto.CityId);
                }

                if ((dto.CategoryId ?? 0) > 0)
                {
                    query = query.Where(x => x.CategoryId == dto.CategoryId);
                }

                if (!string.IsNullOrEmpty(dto.TitleContain))
                {
                    query = query.Where(x => x.Title.ToUpper().Contains(dto.TitleContain.ToUpper()));
                }
                
                var result = query
                    .OrderByDescending(x => x.Id)
                    .Select(p => new PostDto()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = "",

                        CityId = p.CityId,
                        City = p.City.Name + ", " + p.City.State.Abbreviation,
                        CategoryId = p.CategoryId,
                        Category = p.Category.Name,

                        PostalCode = p.PostalCode,
                        ContactEmail = p.ContactEmail,
                        ContactPhone = p.ContactPhone,
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate
                    })
                    .Take(30).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logger.LogTrace(ex, ex.Message);
                return BadRequest("Failed to get posts");
            }
        }

        //GET: api/posts/get/id
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
                _logger.LogError(ex.ToString());
                _logger.LogTrace(ex, ex.Message);
                return BadRequest("Failed to get a post");
            }
        }

        

        //POST: api/posts/addnew
        //model is come from body
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] PostDto dto)
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
                    CityId = dto.CityId,
                    CategoryId = dto.CategoryId,
                    PostalCode = dto.PostalCode,
                    ContactEmail = dto.ContactEmail,
                    ContactPhone = dto.ContactPhone
                };
                _context.Posts.Add(model);

                var result = await _context.SaveChangesAsync(); 
                if ( result > 0)
                {
                    //instead of return 200: Ok, we return 201: Created 
                    return Created($"/api/posts/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logger.LogTrace(ex, ex.Message);
                //_logger.LogError($"Failed to save new user: {ex}");
            }

            return BadRequest("Failed to save a new post");
        }
    }
}