using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
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
