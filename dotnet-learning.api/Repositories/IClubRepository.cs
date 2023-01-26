using dotnet_learning.entities;
using dotnet_learning.commands;

namespace dotnet_learning.Repositories
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
