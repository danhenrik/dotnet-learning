using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IStadiumRepository
    {
        Task<IEnumerable<StadiumQueryResult>> ListAsync();

        Task<StadiumQueryResult> GetAsync(int id);

        Task SaveAsync(Stadium position);

        Task PatchAsync(Stadium position);

        Task DeleteAsync(int id);
    }
}
