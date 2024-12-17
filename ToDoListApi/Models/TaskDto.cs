using ToDoListApi.Data;

namespace ToDoListApi.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatuses Status { get; set; }
        public int Order {  get; set; }
    }
}
