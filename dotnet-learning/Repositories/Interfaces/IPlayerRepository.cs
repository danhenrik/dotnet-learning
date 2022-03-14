using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> CreateAsync(CreatePlayer model);
        Task<List<Player>> GetAllAsync();
        Task<Player> GetByIdAsync(int id);
        Task<Player> UpdateAsync(int id, UpdatePlayer model);
        Task DeleteAsync(int id);
    }  
}
