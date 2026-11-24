using MediatR;

namespace TaskFlow.Application.Commands.RenameProject
{
    public class RenameProjectCommand(Guid id, string name) 
        : IRequest
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
    }
}
