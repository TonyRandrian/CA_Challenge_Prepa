using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project, CancellationToken cancellationToken);
    }
}
