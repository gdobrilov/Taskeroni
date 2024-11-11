using MediatR;
using Taskeroni.Core.Entities;

namespace Taskeroni.Application.Queries
{
    public class GetTaskByIdQuery : IRequest<TodoTask>
    {
        public Guid Id { get; set; }
    }
}
