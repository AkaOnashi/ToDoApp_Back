using Microsoft.EntityFrameworkCore;
using ToDoListApi.Contracts;
using ToDoListApi.Data;

namespace ToDoListApi.Repository
{
    public class TaskRepository : GenericRepository<Data.Task>, ITaskRepository
    {
        private readonly ToDoListDbContext _context;
        public TaskRepository(Data.ToDoListDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Data.Task>> GetByStatusAsync(TaskStatuses taskStatuses)
        {
            return await _context.Tasks.Where(t => t.Status == taskStatuses).ToListAsync();
        }
    }
}
