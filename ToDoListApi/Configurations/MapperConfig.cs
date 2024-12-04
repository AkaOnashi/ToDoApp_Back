using AutoMapper;
using ToDoListApi.Models;

namespace ToDoListApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Data.Task, TaskDto>().ReverseMap();
        }
    }
}
