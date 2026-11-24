using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence
{
    public class TaskFlowDbContext(
        DbContextOptions<TaskFlowDbContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects => Set<Project>();

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(TaskFlowDbContext).Assembly);
        }
    }
}