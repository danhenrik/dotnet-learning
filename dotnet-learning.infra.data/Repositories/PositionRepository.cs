using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public PositionRepository(DataContext context)
        {
            this.context = context;
            this.param = new DynamicParameters();
        }

        public async Task<IEnumerable<PositionQueryResult>> ListAsync() => 
            await context.Connection.QueryAsync<PositionQueryResult>(queries.LocalQueries.LIST);
            
        public async Task<PositionQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<PositionQueryResult>(queries.LocalQueries.GET_BY_ID, new { id });

        public async Task SaveAsync(Position position)
        {
            param.Add("@State", position.Name);

            await context.Connection.ExecuteScalarAsync(queries.LocalQueries.SAVE, param);
        }

        public async Task PatchAsync(Position position)
        {
            param.Add("@Id", position.Id);
            param.Add("@State", position.Name);

            await context.Connection.ExecuteScalarAsync(queries.LocalQueries.UPDATE, param);
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.LocalQueries.DELETE, new { id });

    }
}
