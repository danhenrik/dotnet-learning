using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public LocalRepository(DataContext context)
        {
            this.context = context;
            param = new DynamicParameters();
        }

        public async Task<IEnumerable<LocalQueryResult>> ListAsync() => 
            await context.Connection.QueryAsync<LocalQueryResult>(queries.LocalQueries.LIST);
            
        public async Task<LocalQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<LocalQueryResult>(queries.LocalQueries.GET_BY_ID, new { id });

        public async Task SaveAsync(Local local)
        {
            param.Add("@State", local.State);
            param.Add("@City", local.City);
            param.Add("@Street", local.Street);
            param.Add("@Zip", local.Zip);
            param.Add("@Number", local.Number);

            await context.Connection.ExecuteScalarAsync(queries.LocalQueries.SAVE, param);
        }

        public async Task PatchAsync(Local local)
        {
            param.Add("@Id", local.Id);
            param.Add("@State", local.State);
            param.Add("@City", local.City);
            param.Add("@Street", local.Street);
            param.Add("@Zip", local.Zip);
            param.Add("@Number", local.Number);

            await context.Connection.ExecuteScalarAsync(queries.LocalQueries.UPDATE, param);
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.LocalQueries.DELETE, new { id });
    }
}
