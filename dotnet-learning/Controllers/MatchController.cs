using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetlearning.Database;
using dotnetlearning.ViewModels;
using dotnetlearning.Models;

namespace DotNETAPI.controllers.MatchController
{
    [ApiController]
    [Route("v1")]
    public class MatchController : ControllerBase
    {
        // POST /match
        [HttpPost]
        [Route("match")]
        public async Task<IActionResult> Post([FromServices] AppDbContext db, [FromBody] CreateMatch model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clubA = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == model.ClubAId);

            var clubB = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == model.ClubBId);

            if (clubA == null || clubB == null)
                return NotFound("Um dos 2 clubes não foi encontrado");
            
            var stadium = await db.Stadiums
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == model.StadiumId);
            
            if (stadium == null)
                return NotFound("Estádio não encontrado");

            var match = new Match
            {
                ClubA = clubA,
                ClubB = clubB,
                Stadium = stadium,
                Date = model.Date,
                Time = model.Time,
            };

            db.Matches.Add(match);
            
            var participationList = model.TeamA.Concat(model.TeamB).ToList();

            foreach (ParticipationVM PModel in participationList)
            {
                var player = await db.Players
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == PModel.PlayerId);

                if (player == null)
                    return NotFound("Jogador não encontrado");

                var participation = new Participation
                {
                    Score = PModel.Score,
                    Player = player,
                    Match = match,
                };

                db.Participations.Add(participation);
            }

            await db.SaveChangesAsync();
            return NoContent();
        }

        // GET: /match
        [HttpGet]
        [Route("match")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db)
        {
            var matchs = await db.Matches
                .AsNoTracking()
                .ToListAsync();

            return Ok(matchs);
        }

        // GET /match/5
        [HttpGet]
        [Route("match/{id}")]
        public async Task<IActionResult> Get([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var match = await db.Matches
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
                return NotFound("Partida não encontrada");

            return Ok(match);
        }

        // TODO
        // PUT /match/5
        [HttpPut]
        [Route("match/{id}")]
        public async Task<IActionResult> Put([FromServices] AppDbContext db, [FromRoute] int id, [FromBody] UpdateMatch model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var match = await db.Matches
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
                return NotFound("Jogador não encontrado");

            if (model.ClubAId != null)
            {
                var clubA = await db.Clubs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == model.ClubAId);

                if (clubA == null)
                    return NotFound("Clube A não encontrado");

                match.ClubA = clubA;
            }

            if (model.ClubBId != null)
            {
                var clubB = await db.Clubs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == model.ClubBId);

                if (clubB == null)
                    return NotFound("Clube B não encontrado");

                match.ClubB = clubB;
            }

            if (model.StadiumId != null)
            {
                var stadium = await db.Stadiums
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == model.StadiumId);

                if (stadium == null)
                    return NotFound("Estádio não encontrado");

                match.Stadium = stadium;
            }

            match.Date = model.Date ?? match.Date;
            match.Time = model.Time ?? match.Time;

            var newParticipationList = new List<ParticipationVM>();

            if(model.NewToTeamA != null)
                newParticipationList = newParticipationList.Concat(model.NewToTeamA).ToList();
            
            if(model.NewToTeamB != null)
                newParticipationList = newParticipationList.Concat(model.NewToTeamB).ToList();

            foreach (ParticipationVM PModel in newParticipationList)
            {
                var player = await db.Players
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == PModel.PlayerId);

                if (player == null)
                    return NotFound("Jogador não encontrado");

                var participation = new Participation
                {
                    Score = PModel.Score,
                    Player = player,
                };

                db.Participations.Add(participation);
            }

            var outFromMatch = new List<int>();

            if (model.OutFromTeamA != null)
                outFromMatch = outFromMatch.Concat(model.OutFromTeamA).ToList();

            if (model.OutFromTeamB != null)
                outFromMatch = outFromMatch.Concat(model.OutFromTeamB).ToList();

            foreach(int playeId in outFromMatch)
            {
                var participation = await db.Participations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Player.Id == playeId && p.Match.Id == id);

                if (participation == null)
                    return NotFound($"O jogador sob o ID {playeId} não participou dessa partida e portanto não pode ser retirado");
                
                db.Participations.Remove(participation);
            }

            db.Matches.Update(match);
            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /match/5
        [HttpDelete]
        [Route("match/{id}")]
        public async Task<IActionResult> Delete([FromServices] AppDbContext db, [FromRoute] int id)
        {
            var match = await db.Matches
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
                return NotFound("Jogador não encontrado");

            db.Matches.Remove(match);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
