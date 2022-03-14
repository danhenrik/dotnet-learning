using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetlearning.Database;
using dotnetlearning.ViewModels;
using dotnetlearning.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNETAPI.controllers.PlayerController
{
    [ApiController]
    [Route("v1")]
    public class PlayerController : ControllerBase
    {
        // POST /player
        [HttpPost]
        [Route("player")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreatePlayer model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var club = await db.Clubs
                .FirstOrDefaultAsync(c => c.Id == model.ClubId);

            if (club == null)
                return NotFound("Clube não encontrado");

            var position = await db.Positions
                .FirstOrDefaultAsync(p => p.Id == model.PositionId);

            if (position == null)
                return NotFound("Posição não encontrada");

            var player = new Player
            {
                Name = model.Name,
                Age = model.Age,
                Height = model.Height,
                ShirtNumber = model.ShirtNumber,
                Position = position,
                Club = club,
            };

            db.Players.Add(player);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // GET: /player
        [HttpGet]
        [Route("player")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var players = await db.Players
                .AsNoTracking()
                .Include(p => p.Club)
                .Include(p => p.Position)
                .OrderBy(p => p.Id)
                .ToListAsync();

            return Ok(players);
        }

        // GET /player/5
        [HttpGet]
        [Route("player/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var player = await db.Players
                .AsNoTracking()
                .Include(p => p.Club)
                .Include(p => p.Position)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
                return NotFound("Jogador não encontrado");

            return Ok(player);
        }


        // PUT /player/5
        [HttpPut]
        [Route("player/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdatePlayer model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = await db.Players
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
                return NotFound("Jogador não encontrado");

            if (model.ClubId != null)
            {
                var club = await db.Clubs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == model.ClubId);

                if (club == null)
                    return NotFound("Clube não encontrado");

                player.Club = club;
            }

            if (model.PositionId != null)
            {
                var position = await db.Positions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == model.PositionId);

                if (position == null)
                    return NotFound("Posição não encontrada");

                player.Position = position;
            }

            player.Name = model.Name ?? player.Name;
            player.Height = model.Height ?? player.Height;
            player.Age = model.Age ?? player.Age;
            player.ShirtNumber = model.ShirtNumber ?? player.ShirtNumber;

            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /player/5
        [HttpDelete]
        [Route("player/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var player = await db.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
                return NotFound("Jogador não encontrado");

            db.Players.Remove(player);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
