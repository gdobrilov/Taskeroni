using MediatR;
using Taskeroni.Application.Queries;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Taskeroni.Core.Specifications;

namespace Taskeroni.Application.Handlers
{
    public class GetCompletedTasksQueryHandler : IRequestHandler<GetCompletedTasksQuery, IEnumerable<TodoTask>>
    {
        private readonly ITodoTaskRepository _repository;

        public GetCompletedTasksQueryHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoTask>> Handle(GetCompletedTasksQuery request, CancellationToken cancellationToken)
        {
            var completedSpec = new CompletedTasksSpecification();
            var completedTasks = await _repository.ListAsync(completedSpec);
            return completedTasks;
        }
    }
}
