using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<PlayerQueryResult>> ListAsync();

        Task<PlayerQueryResult> GetAsync(int id);

        Task<PlayerQueryResult> GetClubPlayersAsync(int clubId);
        
        Task<PlayerQueryResult> GetPositionPlayersAsync(int positionId);

        Task SaveAsync(Player player);

        Task PatchAsync(Player player);

        Task DeleteAsync(int id);
    }
}
