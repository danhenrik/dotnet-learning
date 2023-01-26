using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_learning.commands;
using dotnet_learning.entities;
using dotnet_learning.Repositories;

namespace DotNETAPI.controllers.ClubController
{
    [ApiController]
    [Route("v1")]
    public class ClubController : ControllerBase
    {
        ClubRepository clubRepository;

        public ClubController(ClubRepository _clubRepository)
        {
            clubRepository = _clubRepository;
        }

        // POST /club
        [HttpPost]
        [Route("club")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreateClub model)
        {
            try
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
                await db.SaveChangesAsync();

                await clubRepository.CreateAsync(model, local);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /club
        [HttpGet]
        [Route("club")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var clubs = await clubRepository.GetAllAsync();

            return Ok(clubs);
        }

        // GET /club/5
        [HttpGet]
        [Route("club/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var club = await clubRepository.GetByIdAsync(id);

            if (club == null)
                return NotFound("Clube não encontrado");

            return Ok(club);
        }

        // PUT /club/5
        [HttpPut]
        [Route("club/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdateClub model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var club = await clubRepository.UpdateAsync(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE /club/5
        [HttpDelete]
        [Route("club/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            try
            {
                await clubRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
