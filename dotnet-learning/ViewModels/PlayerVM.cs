using System.ComponentModel.DataAnnotations;

namespace dotnetlearning.ViewModels
{
    public class CreatePlayer
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int ShirtNumber { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        public int PositionId { get; set; }
    }

    public class UpdatePlayer
    {
        public string? Name { get; set; }
        public float? Height { get; set; }
        public int? Age { get; set; }
        public int? ShirtNumber { get; set; }
        public int? ClubId { get; set; }
        public int? PositionId { get; set; }
    }
}
