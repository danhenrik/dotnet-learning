using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
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
