using dotnet_learning.Models;
using dotnet_learning.ViewModels;

namespace dotnet_learning.Repositories
{
    public interface IVarRepository
    {
        Task<List<dynamic>> GetTopPlayers();
    }  
}
