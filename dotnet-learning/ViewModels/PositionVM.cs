using System.ComponentModel.DataAnnotations;

namespace dotnetlearning.ViewModels
{
    public class CreatePosition
    {
        [Required]
        public string Name { get; set; }
    }

    public class UpdatePosition
    {
        public string? Name { get; set; }
    }
}
