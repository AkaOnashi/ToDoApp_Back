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
    }
}
