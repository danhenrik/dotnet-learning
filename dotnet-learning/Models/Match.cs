namespace dotnetlearning.Models
{

    public class Match
    {
        public int Id { get; set; }
        public Club ClubA { get; set; }
        public Club ClubB { get; set; }
        public Stadium Stadium { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
