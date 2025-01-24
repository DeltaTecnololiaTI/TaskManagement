using Dapper;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Interfaces;
using TaskManagement.Infra.Context;

namespace TaskManagement.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TaskRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> AddTaskAsync(tabTask task)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                var query = "EXEC usp_AddTask @Title, @Description, @IsCompleted";
                var parameters = new
                {
                    task.Title,
                    task.Description,
                    task.IsCompleted
                };
                return await connection.ExecuteScalarAsync<int>(query, parameters);
            }
        }

        public async Task<IEnumerable<tabTask>> GetAllTasksAsync()
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                var query = "EXEC usp_GetAllTasks";
                return await connection.QueryAsync<tabTask>(query);
            }
        }

        public async Task<tabTask> GetTaskByIdAsync(int id)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                var query = "EXEC usp_GetTaskById @Id";
                var parameters = new { Id = id };
                return await connection.QueryFirstOrDefaultAsync<tabTask>(query, parameters);
            }
        }

        public async Task<bool> UpdateTaskAsync(tabTask task)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                var query = "EXEC usp_UpdateTask @Id, @Title, @Description, @IsCompleted";
                var parameters = new
                {
                    task.Id,
                    task.Title,
                    task.Description,
                    task.IsCompleted
                };
                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                var query = "EXEC usp_DeleteTask @Id";
                var parameters = new { Id = id };
                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }
    }
}

