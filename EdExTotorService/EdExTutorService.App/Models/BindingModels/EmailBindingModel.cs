using System.ComponentModel.DataAnnotations;

namespace EdExTutorService.App.Models.BindingModels
{
    public class EmailBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
    }
}