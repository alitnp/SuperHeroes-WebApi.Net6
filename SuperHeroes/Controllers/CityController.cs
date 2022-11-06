using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.data;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly DataContext _context;

        public CityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> Get()
        {
            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<List<City>>> AddHero(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<City>>> Update(City request)
        {
            var city = await _context.Cities.FindAsync(request.Id);
            if (city == null) return NotFound();

            city.Name = request.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> Delete(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cities.ToListAsync());
        }
    }
}
