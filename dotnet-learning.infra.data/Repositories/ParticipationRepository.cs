using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class ParticipationRepository : IParticipationRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public ParticipationRepository(DataContext context)
        {
            this.context = context;
            param = new DynamicParameters();
        }

        public async Task<IEnumerable<ParticipationQueryResult>> ListAsync() =>
            await context.Connection.QueryAsync<ParticipationQueryResult>(queries.ParticipationQueries.LIST);

        public async Task<ParticipationQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<ParticipationQueryResult>(queries.ParticipationQueries.GET_BY_ID, new {id});
        
        public async Task<IEnumerable<ParticipationQueryResult>> GetPlayerParticipationsAsync(int playerId)
        {
            param.Add("@PlayerId", playerId);
            return await context.Connection.QueryAsync<ParticipationQueryResult>(queries.ParticipationQueries.GET_BY_PLAYER, param);
        }

        public async Task<IEnumerable<ParticipationQueryResult>> GetMatchParticipationsAsync(int matchId)
        {
            param.Add("@MatchId", matchId);
            return await context.Connection.QueryAsync<ParticipationQueryResult>(queries.ParticipationQueries.GET_BY_MATCH, param);
        }

        public async Task SaveAsync(Participation participation)
        {
            param.Add("@MatchId",participation.Match.Id);
            param.Add("@PlayerId",participation.Player.Id);
            param.Add("@Score",participation.Score);

            await context.Connection.ExecuteScalarAsync(queries.ParticipationQueries.SAVE, param);
        }

        public async Task PatchAsync(Participation participation)
        {
            param.Add("@Id", participation.Id);
            param.Add("@MatchId", participation.Match.Id);
            param.Add("@PlayerId", participation.Player.Id);
            param.Add("@Score", participation.Score);

            await context.Connection.ExecuteScalarAsync(queries.ParticipationQueries.UPDATE, param);    
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.ParticipationQueries.DELETE, new { id });
    }
}
