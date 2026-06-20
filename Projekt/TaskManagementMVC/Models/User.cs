using System.ComponentModel.DataAnnotations;

namespace TaskManagementMVC.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100)]
        public string Password { get; set; } = "";

        public ICollection<TaskItem> Tasks { get; set; }
            = new List<TaskItem>();
    }
}