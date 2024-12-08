using ToDoListApi.Data;

namespace ToDoListApi.Contracts
{
    public interface ITaskRepository : IGenericRepository<Data.Task>
    {
        Task<List<Data.Task>> GetByStatusAsync(TaskStatuses taskStatuses);
    }
}
