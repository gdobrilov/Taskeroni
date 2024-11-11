using MediatR;

namespace Taskeroni.Application.Commands
{
    public class MarkTaskAsCompletedCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
