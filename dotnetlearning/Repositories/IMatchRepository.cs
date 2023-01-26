using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IMatchRepository
    {
        Task<IEnumerable<MatchQueryResult>> ListAsync();

        Task<MatchQueryResult> GetAsync(int id);

        Task<IEnumerable<MatchQueryResult>> GetClubMatchesAsync(int clubId);
        
        Task<IEnumerable<MatchQueryResult>> GetStadiumMatchesAsync(int stadiumId);

        Task SaveAsync(Match match);

        Task PatchAsync(Match match);

        Task DeleteAsync(int id);
    }
}
