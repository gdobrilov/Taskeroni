using Microsoft.EntityFrameworkCore;
using Taskeroni.Core.Entities;

namespace Taskeroni.Infrastructure.Data
{
    public class TaskeroniDbContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }

        public TaskeroniDbContext(DbContextOptions<TaskeroniDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}