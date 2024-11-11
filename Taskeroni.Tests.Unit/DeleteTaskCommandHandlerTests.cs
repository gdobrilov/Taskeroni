using Moq;
using Taskeroni.Application.Commands;
using Taskeroni.Application.Handlers;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Xunit;

public class DeleteTaskCommandHandlerTests
{
    private readonly Mock<ITodoTaskRepository> _repositoryMock;
    private readonly DeleteTaskCommandHandler _handler;

    public DeleteTaskCommandHandlerTests()
    {
        _repositoryMock = new Mock<ITodoTaskRepository>();
        _handler = new DeleteTaskCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_TaskExists_DeletesTask()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        var task = new TodoTask { Id = taskId };
        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync(task);
        _repositoryMock.Setup(repo => repo.DeleteAsync(task)).Returns(Task.CompletedTask);

        var command = new DeleteTaskCommand { Id = taskId };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        _repositoryMock.Verify(repo => repo.DeleteAsync(task), Times.Once);
    }

    [Fact]
    public async Task Handle_TaskDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync((TodoTask)null);

        var command = new DeleteTaskCommand { Id = taskId };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
        _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<TodoTask>()), Times.Never);
    }
}
