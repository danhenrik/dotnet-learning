using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Task<Club> CreateAsync(CreateClub model, Local local);
        Task<List<Club>> GetAllAsync();
        Task<Club> GetByIdAsync(int id);
        Task<Club> UpdateAsync(int id, UpdateClub model);
        Task DeleteAsync(int id);
    }
}
