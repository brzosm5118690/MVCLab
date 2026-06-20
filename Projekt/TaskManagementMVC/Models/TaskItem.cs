using System.ComponentModel.DataAnnotations;

namespace TaskManagementMVC.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can contain maximum 100 characters.")]
        public string Title { get; set; } = "";

        [StringLength(500, ErrorMessage = "Description can contain maximum 500 characters.")]
        public string Description { get; set; } = "";

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        // Relacja z User
        [Display(Name = "Assigned User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        // Relacja z Project
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}