using MediatR;
using Taskeroni.Core.Entities;

namespace Taskeroni.Application.Queries
{
    public class GetPendingTasksQuery : IRequest<IEnumerable<TodoTask>> { }
}