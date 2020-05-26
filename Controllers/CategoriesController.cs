using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotnetCore.Data;
using AngularDotnetCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularDotnetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
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
                    .Select(x => new CategoryDto {Id = x.Id, Name = x.Name , CategoryGroupId = x.CategoryGroupId, CategoryGroupName = x.CategoryGroup.Name })
                    .ToListAsync();

                return Ok(allCategories);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get Categories");
            }
        }
    }
}