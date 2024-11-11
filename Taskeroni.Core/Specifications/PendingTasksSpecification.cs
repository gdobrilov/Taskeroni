using Taskeroni.Core.Entities;
using Taskeroni.Core.Specifications.Interfaces;

namespace Taskeroni.Core.Specifications
{
    public class PendingTasksSpecification : ISpecification<TodoTask>
    {
        public bool IsSatisfiedBy(TodoTask task) =>
            !task.IsCompleted && (!task.DueDate.HasValue || task.DueDate.Value >= DateTime.UtcNow);
    }
}

