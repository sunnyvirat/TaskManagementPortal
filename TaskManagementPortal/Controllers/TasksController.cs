using Microsoft.AspNetCore.Mvc;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Tasks task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }

            await _taskService.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetTasksByEmployeeId(int employeeId)
        {
            var tasks = await _taskService.GetTasksByEmployeeIdAsync(employeeId);
            return Ok(tasks);
        }
    }
}

