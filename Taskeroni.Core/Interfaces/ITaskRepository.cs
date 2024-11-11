using Taskeroni.Core.Entities;
using Taskeroni.Core.Specifications.Interfaces;

namespace Taskeroni.Core.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task AddAsync(TodoTask task);
        Task<IEnumerable<TodoTask>> ListAsync(ISpecification<TodoTask> specification);
        Task<TodoTask> GetByIdAsync(Guid id);
        Task UpdateAsync(TodoTask todoTask);
        Task DeleteAsync(TodoTask todoTask);
    }
}