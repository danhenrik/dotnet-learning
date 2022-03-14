using Microsoft.EntityFrameworkCore;
using dotnetlearning.Repositories.Interfaces;
using dotnetlearning.Models;
using dotnetlearning.Database;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories
{
    public class ClubRepository : IClubRepository
    {
        AppDbContext db;

        public ClubRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Club> CreateAsync(CreateClub model, Local local)
        {
            var club = new Club
            {
                Name = model.Name,
                Supporters = model.Supporters,
                Local = local,
            };

            db.Clubs.Add(club);
            await db.SaveChangesAsync();
            
            return club;
        }

        public async Task<List<Club>> GetAllAsync()
        {
            var clubs = await db.Clubs
                .AsNoTracking()
                .Include(c => c.Local)
                .ToListAsync();

            return clubs;
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .Include(c => c.Local)
                .FirstOrDefaultAsync(c => c.Id == id);

            return club;
        }

        public async Task<Club> UpdateAsync(int id, UpdateClub model)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
                throw new Exception("Clube não encontrado");

            club.Name = model.Name ?? club.Name;
            club.Supporters = model.Supporters ?? club.Supporters;

            db.Clubs.Update(club);
            await db.SaveChangesAsync();

            return club;
        }

        public async Task DeleteAsync(int id)
        {
            var club = await db.Clubs
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
                throw new Exception("Clube não encontrado");

            db.Clubs.Remove(club);
            await db.SaveChangesAsync();
        }
    }
}
