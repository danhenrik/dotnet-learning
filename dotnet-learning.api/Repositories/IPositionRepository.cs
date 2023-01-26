using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
{
    public interface IPositionRepository
    {
        Task<Position> CreateAsync(CreatePosition model);
        Task<List<Position>> GetAllAsync();
        Task<Position> GetByIdAsync(int id);
        Task<Position> UpdateAsync(int id, UpdatePosition model);
        Task DeleteAsync(int id);
    }  
}
