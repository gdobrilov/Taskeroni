using Taskeroni.Core.Entities;
using Taskeroni.Core.Factories.Interfaces;

namespace Taskeroni.Core.Factories
{
    public class TodoTaskFactory : ITodoTaskFactory
    {
        public TodoTask CreateTask(string title, DateTime? dueDate = null) =>
            new TodoTask { Id = Guid.NewGuid(), Title = title, DueDate = dueDate };
    }
}