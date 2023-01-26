namespace dotnet_learning.infra.data.queries
{
    public class ParticipationQueries
    {

        public const string LIST =
          @"SELECT * FROM Participations;";

        public const string GET_BY_ID =
         @"SELECT * FROM Participations
           WHERE Id = @Id;";

        public const string GET_BY_PLAYER =
         @"SELECT * FROM Participations
            WHERE PlayerId = @PlayerId;";

        public const string GET_BY_MATCH =
         @"SELECT * FROM Participations
            WHERE MatchId = @MatchId;";
        
        public const string SAVE =
           @"INSERT INTO Participations (
                MatchId, 
                PlayerId, 
                Score)
             VALUES (@MatchId,
             @PlayerId, 
             @Score);";

        public const string UPDATE =
          @"UPDATE Participations
                SET
                    MatchId = @MatchId,
                    PlayerId = @PlayerId, 
                    Score = @Score
                WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Participations
                WHERE Id = @Id;";

    }
}



