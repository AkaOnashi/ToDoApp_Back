using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(t => t.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1,
                    Title = "Watch the video",
                    Description = "",
                    Status = TaskStatuses.ToDo
                },
                new Task
                {
                    Id = 2,
                    Title = "Visit the granny",
                    Description = "Apple street, house 21",
                    Status = TaskStatuses.InProgress
                },
                new Task
                {
                    Id = 3,
                    Title = "To be a chill guy",
                    Description = "",
                    Status = TaskStatuses.Done
                }
                );
        }
    }
}
