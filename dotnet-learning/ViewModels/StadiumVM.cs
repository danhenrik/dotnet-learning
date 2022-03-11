using System.ComponentModel.DataAnnotations;
using dotnetlearning.Models;

namespace dotnetlearning.ViewModels
{
    public class CreateStadium
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AvailableSits { get; set; }
        [Required]
        public CreateLocal Local { get; set; }
    }

    public class UpdateStadium
    {
        public string? Name { get; set; }
        public int? AvailableSits { get; set; }
    }
}
