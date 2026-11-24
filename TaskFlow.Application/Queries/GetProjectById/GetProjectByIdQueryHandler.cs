using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler(IProjectRepository projectRepository)
                : IRequestHandler<GetProjectByIdQuery, Project?>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public Task<Project?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return _projectRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
