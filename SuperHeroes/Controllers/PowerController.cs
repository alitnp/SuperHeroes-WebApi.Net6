using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.data;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : Controller
    {
        private readonly DataContext _context;

        public PowerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Power>>> Get()
        {
            return Ok(await _context.Powers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> Get(int id)
        {
            var power = await _context.Powers.FindAsync(id);
            if (power == null) return NotFound();
            return Ok(power);
        }

        [HttpPost]
        public async Task<ActionResult<List<Power>>> AddHero(Power power)
        {
            _context.Powers.Add(power);
            await _context.SaveChangesAsync();
            return Ok(await _context.Powers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Power>>> Update(Power request)
        {
            var power = await _context.Powers.FindAsync(request.Id);
            if (power == null) return NotFound();

            power.PowerName = request.PowerName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Powers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Power>> Delete(int id)
        {
            var power = await _context.Powers.FindAsync(id);
            if (power == null) return NotFound();

            _context.Powers.Remove(power);
            await _context.SaveChangesAsync();

            return Ok(await _context.Powers.ToListAsync());
        }
    }
}
