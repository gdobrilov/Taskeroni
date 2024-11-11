using Moq;
using Taskeroni.Application.Commands;
using Taskeroni.Application.Handlers;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;

public class MarkTaskAsCompletedCommandHandlerTests
{
    private readonly Mock<ITodoTaskRepository> _repositoryMock;
    private readonly MarkTaskAsCompletedCommandHandler _handler;

    public MarkTaskAsCompletedCommandHandlerTests()
    {
        _repositoryMock = new Mock<ITodoTaskRepository>();
        _handler = new MarkTaskAsCompletedCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldMarkTaskAsCompleted_WhenTaskExists()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        var todoTask = new TodoTask { Id = taskId, Title = "Sample Task" };

        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync(todoTask);

        // Act
        var result = await _handler.Handle(new MarkTaskAsCompletedCommand { Id = taskId }, CancellationToken.None);

        // Assert
        Assert.True(result);
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.Is<TodoTask>(t => t.IsCompleted == true)), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFalse_WhenTaskDoesNotExist()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId)).ReturnsAsync((TodoTask)null);

        // Act
        var result = await _handler.Handle(new MarkTaskAsCompletedCommand { Id = taskId }, CancellationToken.None);

        // Assert
        Assert.False(result);
    }
}
