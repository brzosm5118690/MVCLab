using System.ComponentModel.DataAnnotations;

namespace TaskManagementMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3,ErrorMessage = "Username must contain 3-50 characters.")]
        public string Username { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(50,MinimumLength = 6, ErrorMessage = "Password must contain at least 6 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";
    }
}