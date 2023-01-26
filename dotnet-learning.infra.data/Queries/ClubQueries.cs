namespace dotnet_learning.infra.data.queries
{
    public class ClubQueries
    {

        public const string LIST =
          @"SELECT * FROM Clubs;";

        public const string GET_BY_ID =
         @"SELECT * FROM Clubs
           WHERE Id = @Id;";

        public const string SAVE =
           @"INSERT INTO Clubs 
            (   Name, 
                Supporters, 
                LocalId )
             VALUES (@Name,
                @Supporters, 
                @LocalId );";

        public const string UPDATE =
          @"UPDATE Clubs SET
                Name = @Name,
                Supporters = @Supporters,
                LocalId = @LocalId 
            WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Clubs
                WHERE Id = @Id;";
    }
}



