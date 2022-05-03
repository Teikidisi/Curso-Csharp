using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}
