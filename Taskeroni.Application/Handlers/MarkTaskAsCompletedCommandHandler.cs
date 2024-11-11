using MediatR;
using Taskeroni.Application.Commands;
using Taskeroni.Core.Interfaces;

namespace Taskeroni.Application.Handlers
{
    public class MarkTaskAsCompletedCommandHandler : IRequestHandler<MarkTaskAsCompletedCommand, bool>
    {
        private readonly ITodoTaskRepository _repository;

        public MarkTaskAsCompletedCommandHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(MarkTaskAsCompletedCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
                return false;

            task.MarkAsCompleted();
            await _repository.UpdateAsync(task);

            return true;
        }
    }
}
