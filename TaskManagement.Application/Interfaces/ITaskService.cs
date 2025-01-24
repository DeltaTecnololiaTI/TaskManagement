using TaskManagement.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        Task<int> CreateTaskAsync(CreateTaskDto taskDto);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<bool> UpdateTaskAsync(UpdateTaskDto taskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
