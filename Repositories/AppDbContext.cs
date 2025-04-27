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

            // Seed data
            modelBuilder
                .Entity<Entities.Task>()
                .HasData(
                    new Entities.Task
                    {
                        Id = 1,
                        Name = "Test Task",
                        Description = "This is a test task.",
                        IsCompleted = false
                    }
                );
        }
    }
}
