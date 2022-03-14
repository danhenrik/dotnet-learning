using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetlearning.Database;
using dotnetlearning.ViewModels;
using dotnetlearning.Models;

namespace DotNETAPI.controllers.StadiumController
{
    [ApiController]
    [Route("v1")]
    public class StadiumController : ControllerBase
    {
        // POST /stadium
        [HttpPost]
        [Route("stadium")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreateStadium model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var local = new Local
            {
                City = model.Local.City,
                State = model.Local.State,
                Street = model.Local.Street,
                Zip = model.Local.Zip,
            };

            if (model.Local.Number != null)
                local.Number = model.Local.Number;
            
            db.Locals.Add(local);

            var stadium = new Stadium
            {
                Name = model.Name,
                AvailableSits = model.AvailableSits,
                Local = local,
            };

            db.Stadiums.Add(stadium);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // GET: /stadium
        [HttpGet]
        [Route("stadium")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var stadiums = await db.Stadiums
                .AsNoTracking()
                .Include(s => s.Local)
                .ToListAsync();
            
            return Ok(stadiums);
        }

        // GET /stadium/5
        [HttpGet]
        [Route("stadium/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var stadium = await db.Stadiums
                .AsNoTracking()
                .Include(s => s.Local)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stadium == null)
                return NotFound("Estádio não encontrado");

            return Ok(stadium);
        }

        // PUT /stadium/5
        [HttpPut]
        [Route("stadium/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdateStadium model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var stadium = await db.Stadiums
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stadium == null)
                return NotFound("Estádio não encontrado");

            stadium.Name = model.Name ?? stadium.Name;
            stadium.AvailableSits = model.AvailableSits ?? stadium.AvailableSits;

            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /stadium/5
        [HttpDelete]
        [Route("stadium/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var stadium = await db.Stadiums
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stadium == null)
                return NotFound("Estádio não encontrado");

            db.Stadiums.Remove(stadium);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
