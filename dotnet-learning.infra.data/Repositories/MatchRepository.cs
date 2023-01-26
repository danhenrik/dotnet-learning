using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public MatchRepository(DataContext context)
        {
            this.context = context;
            param = new DynamicParameters();
        }

        public async Task<IEnumerable<MatchQueryResult>> ListAsync() =>
            await context.Connection.QueryAsync<MatchQueryResult>(queries.MatchQueries.LIST);

        public async Task<MatchQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<MatchQueryResult>(queries.MatchQueries.GET_BY_ID, new {id});

        public async Task<IEnumerable<MatchQueryResult>> GetClubMatchesAsync(int clubId)
        {
            param.Add("@ClubId", clubId);
            return await context.Connection.QueryAsync<MatchQueryResult>(queries.MatchQueries.GET_BY_CLUB, param);
        }

        public async Task<IEnumerable<MatchQueryResult>> GetStadiumMatchesAsync(int stadiumId)
        {
            param.Add("@StadiumId", stadiumId);
            return await context.Connection.QueryAsync<MatchQueryResult>(queries.MatchQueries.GET_BY_STADIUM, param);
        }

        public async Task SaveAsync(Match match)
        {
            param.Add("@ClubAId", match.ClubA.Id);
            param.Add("@ClubBId", match.ClubB.Id);
            param.Add("@StadiumId", match.Stadium.Id);
            param.Add("@Date", match.Date);
            param.Add("@Time", match.Time);

            await context.Connection.ExecuteScalarAsync(queries.MatchQueries.SAVE, param);
        }

        public async Task PatchAsync(Match match)
        {
            param.Add("@Id", match.Id);
            param.Add("@ClubAId", match.ClubA.Id);
            param.Add("@ClubBId", match.ClubB.Id);
            param.Add("@StadiumId", match.Stadium.Id);
            param.Add("@Date", match.Date);
            param.Add("@Time", match.Time);

            await context.Connection.ExecuteScalarAsync(queries.MatchQueries.UPDATE, param);    
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.MatchQueries.DELETE, new { id });
    }
}
