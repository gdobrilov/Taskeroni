using MediatR;
using Taskeroni.Application.Commands;
using Taskeroni.Core.Interfaces;

namespace Taskeroni.Application.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITodoTaskRepository _repository;

        public UpdateTaskCommandHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
                return false;

            task.Title = request.Title;
            task.DueDate = request.DueDate;

            await _repository.UpdateAsync(task);
            return true;
        }
    }
}
