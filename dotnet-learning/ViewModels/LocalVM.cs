using System.ComponentModel.DataAnnotations;

namespace dotnetlearning.ViewModels
{
    public class CreateLocal
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        public int? Number { get; set; }
    }

    public class UpdateLocal
    {
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Zip { get; set; }
        public int? Number { get; set; }
    }
}
