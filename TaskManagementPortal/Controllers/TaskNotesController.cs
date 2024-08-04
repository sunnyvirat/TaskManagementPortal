using Microsoft.AspNetCore.Mvc;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskNotesController : ControllerBase
    {
        private readonly ITaskNoteService _taskNoteService;

        public TaskNotesController(ITaskNoteService taskNoteService)
        {
            _taskNoteService = taskNoteService;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskNotes(int taskId)
        {
            var notes = await _taskNoteService.GetTaskNotesAsync(taskId);
            return Ok(notes);
        }

        [HttpPost("{taskId}")]
        public async Task<IActionResult> CreateTaskNote(int taskId, [FromBody] TaskNote taskNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            taskNote.TaskId = taskId;
            await _taskNoteService.CreateTaskNoteAsync(taskNote);
            return CreatedAtAction(nameof(GetTaskNotes), new { taskId = taskId }, taskNote);
        }
    }

}
