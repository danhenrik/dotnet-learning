namespace dotnet_learning.infra.data.queries
{
    public class LocalQueries
    {
        public const string LIST =
          @"SELECT * FROM Locals;";

        public const string GET_BY_ID =
         @"SELECT * FROM  Locals
           WHERE Id = @Id;";

        public const string SAVE =
           @"INSERT INTO Locals (  
                State, 
                City, 
                Street, 
                Zip, 
                Number)
             VALUES (@Nome,
                @State, 
                @City, 
                @Street, 
                @Zip, 
                @Number);";

        public const string UPDATE =
          @"UPDATE Locals
                SET
                    State = @State, 
                    City = @City, 
                    Street = @Street, 
                    Zip = @Zip, 
                    Number = @Number                
            WHERE Id = @Id;";

        public const string DELETE =
            @"DELETE FROM Locals
                WHERE Id = @Id;";

    }
}



