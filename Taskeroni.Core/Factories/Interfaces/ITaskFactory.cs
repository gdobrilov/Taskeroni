using Taskeroni.Core.Entities;

namespace Taskeroni.Core.Factories.Interfaces
{
    public interface ITodoTaskFactory
    {
        TodoTask CreateTask(string title, DateTime? dueDate = null);
    }
}

