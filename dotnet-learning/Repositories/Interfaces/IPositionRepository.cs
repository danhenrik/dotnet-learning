using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
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
