using dotnet_learning.entitites;
using dotnet_learning.query_results;

namespace dotnet_learning.repositories
{
    public interface IParticipationRepository
    {
        Task<IEnumerable<ParticipationQueryResult>> ListAsync();

        Task<ParticipationQueryResult> GetAsync(int id);

        Task<IEnumerable<ParticipationQueryResult>> GetPlayerParticipationsAsync(int playerId);

        Task<IEnumerable<ParticipationQueryResult>> GetMatchParticipationsAsync(int matchId);

        Task SaveAsync(Participation participation);

        Task PatchAsync(Participation participation);

        Task DeleteAsync(int id);
    }
}
