using MediatR;
using Taskeroni.Core.Entities;

namespace Taskeroni.Application.Queries
{
    public class GetOverdueTasksQuery : IRequest<IEnumerable<TodoTask>> { }
}