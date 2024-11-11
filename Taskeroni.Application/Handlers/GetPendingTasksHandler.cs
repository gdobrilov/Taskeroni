using MediatR;
using Taskeroni.Application.Queries;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Taskeroni.Core.Specifications;

public class GetPendingTasksHandler : IRequestHandler<GetPendingTasksQuery, IEnumerable<TodoTask>>
{
    private readonly ITodoTaskRepository _taskRepository;

    public GetPendingTasksHandler(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TodoTask>> Handle(GetPendingTasksQuery request, CancellationToken cancellationToken)
    {
        var specification = new PendingTasksSpecification();
        var pendingTasks = await _taskRepository.ListAsync(specification);
        return pendingTasks;
    }
}