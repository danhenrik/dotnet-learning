using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<PositionQueryResult>> ListAsync();

        Task<PositionQueryResult> GetAsync(int id);

        Task SaveAsync(Position position);

        Task PatchAsync(Position position);

        Task DeleteAsync(int id);
    }
}
