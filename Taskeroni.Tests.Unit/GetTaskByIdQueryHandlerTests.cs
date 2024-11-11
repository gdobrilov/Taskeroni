using Moq;
using Taskeroni.Application.Handlers;
using Taskeroni.Application.Queries;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Xunit;

public class GetTaskByIdQueryHandlerTests
{
    private readonly Mock<ITodoTaskRepository> _repositoryMock;
    private readonly GetTaskByIdQueryHandler _handler;

    public GetTaskByIdQueryHandlerTests()
    {
        _repositoryMock = new Mock<ITodoTaskRepository>();
        _handler = new GetTaskByIdQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_TaskExists_ReturnsTask()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        var task = new TodoTask { Id = taskId, Title = "Sample Task" };
        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId))
                       .ReturnsAsync(task);

        var query = new GetTaskByIdQuery { Id = taskId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(taskId, result.Id);
    }

    [Fact]
    public async Task Handle_TaskDoesNotExist_ReturnsNull()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        _repositoryMock.Setup(repo => repo.GetByIdAsync(taskId))
                       .ReturnsAsync((TodoTask)null);

        var query = new GetTaskByIdQuery { Id = taskId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
