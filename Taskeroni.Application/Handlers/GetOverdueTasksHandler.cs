using MediatR;
using Taskeroni.Application.Queries;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Taskeroni.Core.Specifications;

public class GetOverdueTasksHandler : IRequestHandler<GetOverdueTasksQuery, IEnumerable<TodoTask>>
{
    private readonly ITodoTaskRepository _taskRepository;

    public GetOverdueTasksHandler(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TodoTask>> Handle(GetOverdueTasksQuery request, CancellationToken cancellationToken)
    {
        var specification = new OverdueTasksSpecification();
        var overdueTasks = await _taskRepository.ListAsync(specification);
        return overdueTasks;
    }
}