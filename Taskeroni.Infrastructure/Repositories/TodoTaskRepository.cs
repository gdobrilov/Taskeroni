using Microsoft.EntityFrameworkCore;
using Taskeroni.Core.Entities;
using Taskeroni.Core.Interfaces;
using Taskeroni.Core.Specifications.Interfaces;
using Taskeroni.Infrastructure.Data;

namespace Taskeroni.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TaskeroniDbContext _context;

        public TodoTaskRepository(TaskeroniDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoTask todoTask)
        {
            await _context.TodoTasks.AddAsync(todoTask);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoTask>> ListAsync(ISpecification<TodoTask> specification)
        {
            var tasks = await _context.TodoTasks.ToListAsync();
            return tasks.FindAll(t => specification.IsSatisfiedBy(t));
        }

        public async Task<TodoTask> GetByIdAsync(Guid id)
        {
            return await _context.TodoTasks.FindAsync(id);
        }

        public async Task UpdateAsync(TodoTask todoTask)
        {
            _context.TodoTasks.Update(todoTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TodoTask todoTask)
        {
            _context.TodoTasks.Remove(todoTask);
            await _context.SaveChangesAsync();
        }
    }
}
