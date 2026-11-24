using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void CreateProject_WithValidData_ShouldCreateProject()
        {
            // Arrange
            string name = "TaskFlow";
            string description = "Project management application";

            // Act
            Project project = new(name, description);

            // Assert
            Assert.NotEqual(Guid.Empty, project.Id);
            Assert.Equal(name, project.Name);
            Assert.Equal(description, project.Description);
            Assert.Equal(ProjectStatus.Active, project.Status);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        public void CreateProject_WithInvalidName_ShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
                new Project(name, "Description"));
        }

        [Fact]
        public void ArchiveProject_WithActiveProject_ShouldChangeStatusToArchived()
        {
            // Arrange
            Project project = new(
                "TaskFlow",
                "Project management application");

            // Act
            project.Archive();

            // Assert
            Assert.Equal(ProjectStatus.Archived, project.Status);
        }

        [Fact]
        public void RenameProject_WithArchivedProject_ShouldThrowException()
        {
            // Arrange
            Project project = new("TaskFlow", "Description");
            project.Archive();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                project.Rename("New name"));
        }
    }
}
