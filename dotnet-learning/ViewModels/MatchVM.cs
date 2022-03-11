using System.ComponentModel.DataAnnotations;

namespace dotnetlearning.ViewModels
{
    public class CreateMatch
    {
        [Required]
        public int ClubAId { get; set; }
        [Required]
        public int ClubBId { get; set; }
        [Required]
        public List<ParticipationVM> TeamA { get; set; }
        [Required]
        public List<ParticipationVM> TeamB { get; set; }
        [Required]
        public int StadiumId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
    }

    public class UpdateMatch
    {
        public int? ClubAId { get; set; }
        public int? ClubBId { get; set; }
        public List<ParticipationVM>? NewToTeamA { get; set; }
        public List<ParticipationVM>? NewToTeamB { get; set; }
        public List<int>? OutFromTeamA{ get; set; }
        public List<int>? OutFromTeamB { get; set; }
        public int? StadiumId { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
    }
}
