using Taskeroni.Core.Entities;
using Taskeroni.Core.Specifications.Interfaces;

namespace Taskeroni.Core.Specifications
{
    public class CompletedTasksSpecification : ISpecification<TodoTask>
    {
        public bool IsSatisfiedBy(TodoTask task)
        {
            return task.IsCompleted;
        }
    }
}
