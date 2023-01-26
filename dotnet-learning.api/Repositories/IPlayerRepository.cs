using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
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
