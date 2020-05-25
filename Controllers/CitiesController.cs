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
    public class CitiesController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/cities/all
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var allCities = await _context.Cities.Include(c=>c.State)
                    .OrderBy(x => x.StateId)
                    .ThenBy(x => x.Id)
                    .Select(x => new CityDto {Id = x.Id, Name = x.Name + ", " + x.State.Abbreviation })
                    .ToListAsync();

                return Ok(allCities);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get cities");
            }
        }
    }
}