using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
{
    public interface ILocalRepository
    {
        Task<Local> CreateAsync(CreateLocal model);
        Task<List<Local>> GetAllAsync();
        Task<Local> GetByIdAsync(int id);
        Task<Local> UpdateAsync(int id, UpdateLocal model);
        Task DeleteAsync(int id);
    }  
}
