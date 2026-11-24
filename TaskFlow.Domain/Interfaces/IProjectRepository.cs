using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project, CancellationToken cancellationToken);
        Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(Project project, CancellationToken cancellationToken);
    }
}
