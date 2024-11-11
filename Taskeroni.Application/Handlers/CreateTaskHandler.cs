using MediatR;
using Taskeroni.Application.Commands;
using Taskeroni.Core.Factories.Interfaces;
using Taskeroni.Core.Interfaces;

namespace Taskeroni.Application.Handlers;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITodoTaskFactory _taskFactory;
    private readonly ITodoTaskRepository _taskRepository;

    public CreateTaskHandler(ITodoTaskFactory taskFactory, ITodoTaskRepository taskRepository)
    {
        _taskFactory = taskFactory;
        _taskRepository = taskRepository;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = _taskFactory.CreateTask(request.Title, request.DueDate);
        await _taskRepository.AddAsync(task);
        return task.Id;
    }
}