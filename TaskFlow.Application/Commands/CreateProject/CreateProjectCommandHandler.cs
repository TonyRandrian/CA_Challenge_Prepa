using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler(IProjectRepository projectRepository)
                : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;


        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = new(request.Name, request.Description);

            await _projectRepository.AddAsync(project, cancellationToken);

            return project.Id;
        }
    }
}
