using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IClubRepository
    {
        Task<IEnumerable<ClubQueryResult>> ListAsync();

        Task<ClubQueryResult> GetAsync(int id);

        Task SaveAsync(Club empresa);

        Task PatchAsync(Club empresa);

        Task DeleteAsync(int id);
    }
}
