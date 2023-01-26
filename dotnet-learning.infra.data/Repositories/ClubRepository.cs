using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public ClubRepository(DataContext context)
        {
            this.context = context;
            param = new DynamicParameters();
        }

        public async Task<IEnumerable<ClubQueryResult>> ListAsync() => 
            await context.Connection.QueryAsync<ClubQueryResult>(queries.ClubQueries.LIST);
        

        public async Task<ClubQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<ClubQueryResult>(queries.ClubQueries.GET_BY_ID, new { id });

        public async Task SaveAsync(Club club)
        {
            param.Add("@Nome", club.Name);
            param.Add("@Supporters", club.Supporters);
            param.Add("@NomeCurto", club.Local.Id);

            await context.Connection.ExecuteScalarAsync(queries.ClubQueries.SAVE, param);
        }

        public async Task PatchAsync(Club club)
        {
            param.Add("@Id", club.Id);
            param.Add("@Nome", club.Name);
            param.Add("@Supporters", club.Supporters);
            param.Add("@NomeCurto", club.Local.Id);

            await context.Connection.ExecuteScalarAsync(queries.ClubQueries.UPDATE, param);
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.ClubQueries.DELETE, new { id });
    }
}
