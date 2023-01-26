using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_learning.Database;
using dotnet_learning.ViewModels;
using dotnet_learning.Models;

namespace DotNETAPI.controllers.PositionController
{
    [ApiController]
    [Route("v1")]
    public class PositionController : ControllerBase
    {
        // POST /position
        [HttpPost]
        [Route("position")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreatePosition model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var position = new Position
            {
                Name = model.Name,
            };


            db.Positions.Add(position);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // GET: /position
        [HttpGet]
        [Route("position")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var positions = await db.Positions
                .AsNoTracking()
                .ToListAsync();

            return Ok(positions);
        }

        // GET /position/5
        [HttpGet]
        [Route("position/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var position = await db.Positions
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (position == null)
                return NotFound("Posição não encontrada");
            
            return Ok(position);
        }

        // PUT /position/5
        [HttpPut]
        [Route("position/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdatePosition model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var position = await db.Positions
                .FirstOrDefaultAsync(p => p.Id == id);

            if (position == null)
                return NotFound("Posição não encontrada");

            position.Name = model.Name ?? position.Name;

            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /position/5
        [HttpDelete]
        [Route("position/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var position = await db.Positions
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (position == null)
                return NotFound("Posição não encontrada");

            db.Positions.Remove(position);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
