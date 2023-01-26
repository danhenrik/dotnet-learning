namespace dotnet_learning.infra.data.queries
{
    public class MatchQueries
    {

        public const string LIST =
            @"SELECT * FROM Matches";

        public const string GET_BY_ID =
            @"SELECT * FROM Matches
                WHERE Id = @Id";

        public const string GET_BY_CLUB = 
            @"SELECT * FROM Matches
                WHERE ClubAId = @ClubId 
                OR ClubBId = @ClubId;";
        
        public const string GET_BY_STADIUM = 
            @"SELECT * FROM Matches
                WHERE StadiumId = @StadiumId;";

        public const string SAVE =
            @"INSERT INTO Matches (
                ClubAId, 
                ClubBId, 
                StadiumId, 
                Date, 
                Time)
             VALUES (
                @ClubAId, 
                @ClubBId, 
                @StadiumId, 
                @Date, 
                @Time);";

        public const string UPDATE =
            @"UPDATE Matches
                SET
                    ClubAId = @ClubAId, 
                    ClubBId = @ClubBId, 
                    StadiumId = @StadiumId, 
                    Date = @Date, 
                    Time = @Time
                WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Matches
                WHERE Id = @Id;";
    }
}



