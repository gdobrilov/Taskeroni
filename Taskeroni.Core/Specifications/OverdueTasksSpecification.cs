using Taskeroni.Core.Entities;
using Taskeroni.Core.Specifications.Interfaces;

namespace Taskeroni.Core.Specifications
{
    public class OverdueTasksSpecification : ISpecification<TodoTask>
    {
        public bool IsSatisfiedBy(TodoTask task) => task.IsOverdue();
    }
}

