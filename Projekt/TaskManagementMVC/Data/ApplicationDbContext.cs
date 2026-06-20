using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}