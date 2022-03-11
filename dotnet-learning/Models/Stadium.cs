namespace dotnetlearning.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableSits { get; set; }
        public Local Local { get; set; }
    }
}
