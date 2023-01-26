using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface ILocalRepository
    {
        Task<IEnumerable<LocalQueryResult>> ListAsync();

        Task<LocalQueryResult> GetAsync(int id);

        Task SaveAsync(Local local);

        Task PatchAsync(Local local);

        Task DeleteAsync(int id);
    }
}
