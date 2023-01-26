using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_learning.Database;
using dotnet_learning.ViewModels;

namespace DotNETAPI.controllers.LocalController
{
    [ApiController]
    [Route("v1")]
    public class LocalController : ControllerBase
    {
        // GET: /local
        [HttpGet]
        [Route("local")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var locals = await db.Locals
                .AsNoTracking()
                .ToListAsync();

            return Ok(locals);
        }

        // GET /local/5
        [HttpGet]
        [Route("local/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var local = await db.Locals
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (local == null)
                return NotFound("Localização não encontrada");

            return Ok(local);
        }

        // PUT /local/5
        [HttpPut]
        [Route("local/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdateLocal model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var local = await db.Locals
                .FirstOrDefaultAsync(l => l.Id == id);

            if (local == null)
                return NotFound("Localização não encontrada");

            local.State = model.State ?? local.State;
            local.Street = model.Street ?? local.Street;
            local.City = model.City ?? local.City;
            local.Zip = model.Zip ?? local.Zip;
            local.Number = model.Number ?? local.Number;

            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /local/5
        [HttpDelete]
        [Route("local/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var local = await db.Locals
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (local == null)
                return NotFound("Localização não encontrada");

            db.Locals.Remove(local);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
