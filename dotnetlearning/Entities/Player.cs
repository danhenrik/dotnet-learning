namespace dotnet_learning.entitites
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Height { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }
        public Club Club { get; set; }
        public Position Position { get; set; }
    }
}
