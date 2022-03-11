using System.ComponentModel.DataAnnotations;
using dotnetlearning.Models;

namespace dotnetlearning.ViewModels
{
    public class CreateClub
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Supporters { get; set; }
        [Required]
        public CreateLocal Local { get; set; }
    }

    public class UpdateClub
    {
        public string? Name { get; set; }
        public int? Supporters { get; set; }
    }
}
