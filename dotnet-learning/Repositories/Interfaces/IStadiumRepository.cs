using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
{
    public interface IStadiumRepository
    {
        Task<Stadium> CreateAsync(CreateStadium model);
        Task<List<Stadium>> GetAllAsync();
        Task<Stadium> GetByIdAsync(int id);
        Task<Stadium> UpdateAsync(int id, UpdateStadium model);
        Task DeleteAsync(int id);
    }  
}
