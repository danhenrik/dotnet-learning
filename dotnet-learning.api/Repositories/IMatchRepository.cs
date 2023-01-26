using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
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
