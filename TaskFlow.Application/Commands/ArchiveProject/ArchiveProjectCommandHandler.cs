using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Commands.ArchiveProject
{
    public class ArchiveProjectCommandHandler(IProjectRepository projectRepository)
        : IRequestHandler<ArchiveProjectCommand>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task Handle(ArchiveProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new ProjectNotFoundException(request.Id);

            project.Archive();
            await _projectRepository.UpdateAsync(project, cancellationToken);
        }
    }
}
