using MediatR;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery(Guid id) : IRequest<Project?>
    {
        public Guid Id { get; init; } = id;
    }
}
