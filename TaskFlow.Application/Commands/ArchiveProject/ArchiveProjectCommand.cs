using MediatR;

namespace TaskFlow.Application.Commands.ArchiveProject
{
    public class ArchiveProjectCommand(Guid id) : IRequest
    {
        public Guid Id { get; init; } = id;
    }
}
