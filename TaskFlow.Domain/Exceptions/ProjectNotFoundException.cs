namespace TaskFlow.Domain.Exceptions
{
    public class ProjectNotFoundException(Guid id) 
        : Exception($"Project with ID '{id}' was not found")
    {
        public Guid Id { get; } = id;
    }
}
