namespace dotnet_learning.infra.data.queries
{
    public class StadiumQueries
    {

        public const string LIST =
          @"SELECT * FROM Stadiums;";

        public const string GET_BY_ID =
         @"SELECT * FROM  Stadiums
           WHERE Id = @Id;";

        public const string SAVE =
           @"INSERT INTO Stadiums (
                Name, 
                AvailableSits, 
                LocalId)
             VALUES (@Name,
                @AvailableSits, 
                @LocalId);";

        public const string UPDATE =
          @"UPDATE Stadiums
                SET
                     Name = @Name,
                     AvailableSits = @AvailableSits,
                     LocalId = @LocalId
                WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Stadiums
                WHERE Id = @Id;";

    }
}



