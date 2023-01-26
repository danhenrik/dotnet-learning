using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public StadiumRepository(DataContext context)
        {
            this.context = context;
            this.param = new DynamicParameters();
        }

        public async Task<IEnumerable<StadiumQueryResult>> ListAsync() => 
            await context.Connection.QueryAsync<StadiumQueryResult>(queries.StadiumQueries.LIST);
            
        public async Task<StadiumQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<StadiumQueryResult>(queries.StadiumQueries.GET_BY_ID, new { id });

        public async Task SaveAsync(Stadium stadium)
        {
            param.Add("@State", stadium.Name);
            param.Add("@AvailableSits", stadium.AvailableSits);
            param.Add("@LocalId", stadium.Local.Id);

            await context.Connection.ExecuteScalarAsync(queries.StadiumQueries.SAVE, param);
        }

        public async Task PatchAsync(Stadium stadium)
        {
            param.Add("@Id", stadium.Id);
            param.Add("@State", stadium.Name);
            param.Add("@AvailableSits", stadium.AvailableSits);
            param.Add("@LocalId", stadium.Local.Id);

            await context.Connection.ExecuteScalarAsync(queries.StadiumQueries.UPDATE, param);
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.StadiumQueries.DELETE, new { id });

    }
}
