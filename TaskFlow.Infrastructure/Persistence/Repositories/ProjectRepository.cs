using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository(TaskFlowDbContext context) : IProjectRepository
    {
        private readonly TaskFlowDbContext _context = context;


        public async Task AddAsync(Project project, CancellationToken cancellationToken)
        {
            await _context.Projects.AddAsync(project, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
