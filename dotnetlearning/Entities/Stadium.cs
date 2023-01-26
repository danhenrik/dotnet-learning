namespace dotnet_learning.entitites
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableSits { get; set; }
        public Local Local { get; set; }
    }
}
