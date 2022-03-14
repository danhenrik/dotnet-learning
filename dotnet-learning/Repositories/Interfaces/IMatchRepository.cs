using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> CreateAsync(CreateMatch model);
        Task<List<Match>> GetAllAsync();
        Task<Match> GetByIdAsync(int id);
        Task<Match> UpdateAsync(int id, UpdateMatch model);
        Task DeleteAsync(int id);
    }  
}
