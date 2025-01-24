using AutoMapper;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Interfaces;

namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateTaskAsync(CreateTaskDto taskDto)
        {
            var task = _mapper.Map<tabTask>(taskDto);
            return await _taskRepository.AddTaskAsync(task);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<bool> UpdateTaskAsync(UpdateTaskDto taskDto)
        {
            var task = _mapper.Map<tabTask>(taskDto);
            return await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}

