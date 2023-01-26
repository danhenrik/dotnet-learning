using Dapper;
using dotnet_learning.entitites;
using dotnet_learning.query_results;
using dotnet_learning.repositories;

namespace dotnet_learning.infra.data.repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext context;
        private readonly DynamicParameters param;

        public PlayerRepository(DataContext context)
        {
            this.context = context;
            param = new DynamicParameters();
        }

        public async Task<IEnumerable<PlayerQueryResult>> ListAsync() =>
            await context.Connection.QueryAsync<PlayerQueryResult>(queries.PlayerQueries.LIST);

        public async Task<PlayerQueryResult> GetAsync(int id) =>
            await context.Connection.QueryFirstOrDefaultAsync<PlayerQueryResult>(queries.PlayerQueries.GET_BY_ID, new {id});

        public async Task<IEnumerable<PlayerQueryResult>> GetClubPlayersAsync(int clubId)
        {
            param.Add("@ClubId", clubId);
            return await context.Connection.QueryAsync<PlayerQueryResult>(queries.PlayerQueries.GET_BY_CLUB, param);
        }

        public async Task<IEnumerable<PlayerQueryResult>> GetPositionPlayerAsync(int positionId)
        {
            param.Add("@PositionId", positionId);
            return await context.Connection.QueryAsync<PlayerQueryResult>(queries.PlayerQueries.GET_BY_POSITION, param);
        }

        public async Task SaveAsync(Player player)
        {
            param.Add("@Name", player.Name);
            param.Add("@Height", player.Height);
            param.Add("@Age", player.Age);
            param.Add("@ShirtNumber", player.ShirtNumber);
            param.Add("@ClubId", player.Club.Id);
            param.Add("@PositionId", player.Position.Id);

            await context.Connection.ExecuteScalarAsync(queries.PlayerQueries.SAVE, param);
        }

        public async Task PatchAsync(Player player)
        {
            param.Add("@Id", player.Id);
            param.Add("@Name", player.Name);
            param.Add("@Height", player.Height);
            param.Add("@Age", player.Age);
            param.Add("@ShirtNumber", player.ShirtNumber);
            param.Add("@ClubId", player.Club.Id);
            param.Add("@PositionId", player.Position.Id);

            await context.Connection.ExecuteScalarAsync(queries.PlayerQueries.UPDATE, param);    
        }

        public async Task DeleteAsync(int id) =>
            await context.Connection.ExecuteAsync(queries.PlayerQueries.DELETE, new { id });

        Task<PlayerQueryResult> IPlayerRepository.GetClubPlayersAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerQueryResult> GetPositionPlayersAsync(int positionId)
        {
            throw new NotImplementedException();
        }
    }
}
