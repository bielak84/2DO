using Microsoft.EntityFrameworkCore;

namespace _2DO
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=main.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(
            new Task
            {
                Id = 1,
                CategoryId = 1,
                Description = "Example task",
                Title = "Example task",
                notificationThreshold = TimeSpan.FromMinutes(10),
                EndDate = DateTime.Now.AddHours(5),
                notifiedOnEndDate = false,
                notifiedOnThreshold = false,
                TaskCompleted = false,
                Priority = TaskPriority.Medium,
                StartDate = DateTime.Now,
            });
            modelBuilder.Entity<Category>().HasData(
            new Category { 
                Id = 1,
                Name = "Example category"
            });
        }
    }
}
