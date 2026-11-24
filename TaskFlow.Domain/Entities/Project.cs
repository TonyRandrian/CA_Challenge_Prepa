namespace TaskFlow.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public ProjectStatus Status { get; private set; }


        private Project() { }

        public Project(string name, string description)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            Status = ProjectStatus.Active;

            SetName(name);
            SetDescription(description);
        }

        public void Rename(string name)
        {
            EnsureIsActive();

            SetName(name);
        }

        public void UpdateDescription(string description)
        {
            EnsureIsActive();

            SetDescription(description);
        }

        public void Archive()
        {
            EnsureIsActive();

            Status = ProjectStatus.Archived;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            Name = name.Trim();

            if (name.Length > 100)
                throw new ArgumentException("Name cannot exceed 100 characters.");
        }

        private void SetDescription(string description)
        {
            description = description?.Trim() ?? string.Empty;

            if (description.Length > 500)
                throw new ArgumentException("Description cannot exceed 500 characters");

            Description = description;
        }

        private void EnsureIsActive()
        {
            if (Status == ProjectStatus.Archived)
                throw new InvalidOperationException("Archived projects cannot be modified");
        }
    }
}
