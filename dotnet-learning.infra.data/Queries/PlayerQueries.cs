namespace dotnet_learning.infra.data.queries
{
    public class PlayerQueries
    {

        public const string LIST =
          @"SELECT * FROM Players;";

        public const string GET_BY_ID =
         @"SELECT * FROM Players
           WHERE Id = @Id;";

        public const string GET_BY_CLUB =
            @"SELECT * FROM Players
                WHERE ClubId = @ClubId;";

        public const string GET_BY_POSITION=
            @"SELECT * FROM Players
                WHERE PositionId = @PositionId;";

        public const string SAVE =
           @"INSERT INTO Players (
                Name, 
                Height, 
                Age, 
                ShirtNumber, 
                ClubId, 
                PositionId)
             VALUES (@Name, 
                @Height, 
                @Age, 
                @ShirtNumber, 
                @ClubId, 
                @PositionId);";

        public const string UPDATE =
          @"UPDATE Players
                SET
                    Name = @Name, 
                    Height = @Height, 
                    Age = @Age, 
                    ShirtNumber = @ShirtNumber, 
                    ClubId = @ClubId, 
                    PositionId = @PositionId,
                WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Players
                WHERE Id = @Id;";

    }
}



