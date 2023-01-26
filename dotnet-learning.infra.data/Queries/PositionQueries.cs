namespace dotnet_learning.infra.data.queries
{
    public class PositionQueries
    {

        public const string LIST =
          @"SELECT Name FROM Positions;";

        public const string GET_BY_ID =
         @"SELECT Name FROM Positions
           WHERE Id = @Id;";

        public const string SAVE =
           @"INSERT INTO Positions (  Name )
             VALUES (@Nome);";

        public const string UPDATE =
          @"UPDATE empresa SET 
            Nome = @Nome,
            WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM empresa
              WHERE Id = @Id;";

    }
}



