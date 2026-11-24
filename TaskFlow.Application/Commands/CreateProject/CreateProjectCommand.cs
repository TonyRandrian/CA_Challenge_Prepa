using MediatR;

namespace TaskFlow.Application.Commands.CreateProject
{
    public class CreateProjectCommand(string name, string description) : IRequest<Guid>
    {
        public string Name { get; init; } = name;
        public string Description { get; init; } = description;
    }
}
