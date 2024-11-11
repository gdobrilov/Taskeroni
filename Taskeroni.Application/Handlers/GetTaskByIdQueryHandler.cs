using MediatR;
using Taskeroni.Application.Queries;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;

namespace Taskeroni.Application.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TodoTask>
    {
        private readonly ITodoTaskRepository _repository;

        public GetTaskByIdQueryHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
