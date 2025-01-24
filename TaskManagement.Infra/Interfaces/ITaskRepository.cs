
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infra.Interfaces
{
    public interface ITaskRepository
    {
        Task<int> AddTaskAsync(tabTask task);
        Task<IEnumerable<tabTask>> GetAllTasksAsync();
        Task<tabTask> GetTaskByIdAsync(int id);
        Task<bool> UpdateTaskAsync(tabTask task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
