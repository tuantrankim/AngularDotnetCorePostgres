using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotnetCore.Data;
using AngularDotnetCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AngularDotnetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private ApplicationDbContext _context;
        public CategoriesController(ILogger<CategoriesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/Categories/all
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var allCategories = await _context.Categories.Include(c=>c.CategoryGroup)
                    .OrderBy(x => x.CategoryGroupId)
                    .ThenBy(x => x.Id)
                    .Select(x => new CategoryDto {
                        Id = x.Id, 
                        Icon = x.Icon,
                        Name = x.Name , 
                        CategoryGroupId = x.CategoryGroupId, 
                        CategoryGroupName = x.CategoryGroup.Name
                    })
                    .ToListAsync();

                return Ok(allCategories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logger.LogTrace(ex, ex.Message);
                return BadRequest("Failed to get Categories");
            }
        }
    }
}