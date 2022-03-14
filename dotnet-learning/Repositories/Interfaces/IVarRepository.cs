using dotnetlearning.Models;
using dotnetlearning.ViewModels;

namespace dotnetlearning.Repositories.Interfaces
{
    public interface IVarRepository
    {
        Task<List<dynamic>> GetTopPlayers();
    }  
}
