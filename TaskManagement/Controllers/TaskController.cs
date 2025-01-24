using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Dtos;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // POST /tasks - Adiciona uma nova tarefa
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto taskCreateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _taskService.CreateTaskAsync(taskCreateDto);
        return CreatedAtAction(nameof(GetTaskById), new { id = result }, result);
    }

    // GET /tasks - Lista todas as tarefas
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    // GET /tasks/{id} - Retorna uma tarefa específica
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // PUT /tasks/{id} - Atualiza uma tarefa existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto taskUpdateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _taskService.UpdateTaskAsync(taskUpdateDto);
        if (!result)
            return NotFound();

        return NoContent();
    }

    // DELETE /tasks/{id} - Exclui uma tarefa
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var result = await _taskService.DeleteTaskAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
