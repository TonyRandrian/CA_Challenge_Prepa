using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Commands.RenameProject
{
    public class RenameProjectCommandHandler(IProjectRepository projectRepository)
        : IRequestHandler<RenameProjectCommand>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;


        public async Task Handle(RenameProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new ProjectNotFoundException(request.Id);

            project.Rename(request.Name);
            await _projectRepository.UpdateAsync(project, cancellationToken);
        }
    }
}
