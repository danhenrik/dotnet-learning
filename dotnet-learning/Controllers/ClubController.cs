using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetlearning.Database;
using dotnetlearning.ViewModels;
using dotnetlearning.Models;

namespace DotNETAPI.controllers.ClubController
{
    [ApiController]
    [Route("v1")]
    public class ClubController : ControllerBase
    {
        // POST /club
        [HttpPost]
        [Route("club")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreateClub model)
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

            var club = new Club
            {
                Name = model.Name,
                Supporters = model.Supporters,
                Local = local,
            };

            db.Clubs.Add(club);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // GET: /club
        [HttpGet]
        [Route("club")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .Include(c => c.Local)
                .ToListAsync();


            return Ok(club);
        }

        // GET /club/5
        [HttpGet]
        [Route("club/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .Include(c => c.Local)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
                return NotFound("Clube não encontrado");
            return Ok(club);
        }

        // PUT /club/5
        [HttpPut]
        [Route("club/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdateClub model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var club = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
                return NotFound("Clube não encontrado");

            club.Name = model.Name ?? club.Name;
            club.Supporters = model.Supporters ?? club.Supporters;

            db.Clubs.Update(club);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /club/5
        [HttpDelete]
        [Route("club/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
                return NotFound("Clube não encontrado");

            db.Clubs.Remove(club);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
