namespace dotnet_learning.entitites
{
    public class Participation
    {
        public int Id { get; set; }
        public  Match Match { get; set; }
        public Player Player { get; set; }
        public int Score { get; set; }
    }
}
