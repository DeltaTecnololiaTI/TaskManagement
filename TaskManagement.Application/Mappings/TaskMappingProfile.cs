using AutoMapper;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<tabTask, TaskDto>().ReverseMap();
            CreateMap<tabTask, CreateTaskDto>().ReverseMap();
            CreateMap<tabTask, UpdateTaskDto>().ReverseMap();
        }
    }
}
