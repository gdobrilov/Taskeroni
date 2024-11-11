using MediatR;
using Taskeroni.Core.Entities;

namespace Taskeroni.Application.Queries
{
    public class GetCompletedTasksQuery : IRequest<IEnumerable<TodoTask>>
    {
    }
}
