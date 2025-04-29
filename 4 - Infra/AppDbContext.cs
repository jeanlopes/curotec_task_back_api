using Microsoft.EntityFrameworkCore;

namespace CurotecTaskBackApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entities.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Task entity
            modelBuilder.Entity<Entities.Task>(entity =>
            {
                entity.HasKey(t => t.Id); // Set Id as Primary Key
                entity.Property(t => t.Id).ValueGeneratedOnAdd(); // Set Id to auto-increment
            });

            // Seed data
            modelBuilder
                .Entity<Entities.Task>()
                .HasData(
                    new Entities.Task
                    {
                        Id = 1,
                        Description = "This is a test task.",
                        IsCompleted = false,
                        CreatedDate = DateTime.UtcNow,
                        Status = (int)Entities.TaskStatus.Pending,
                        Title = "Test Task Title"
                    }
                );
        }
    }
}
