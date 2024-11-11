using MediatR;
using Taskeroni.Application.Commands;
using Taskeroni.Core.Interfaces;

namespace Taskeroni.Application.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITodoTaskRepository _repository;

        public DeleteTaskCommandHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
                return false;

            await _repository.DeleteAsync(task);
            return true;
        }
    }
}
