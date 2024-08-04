using Microsoft.AspNetCore.Mvc;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskDocumentsController : ControllerBase
    {
        private readonly ITaskDocumentService _taskDocumentService;

        public TaskDocumentsController(ITaskDocumentService taskDocumentService)
        {
            _taskDocumentService = taskDocumentService;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskDocuments(int taskId)
        {
            var documents = await _taskDocumentService.GetTaskDocumentsAsync(taskId);
            return Ok(documents);
        }

        [HttpPost("{taskId}")]
        public async Task<IActionResult> CreateTaskDocument(int taskId, [FromBody] TaskDocument taskDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            taskDocument.TaskId = taskId;
            await _taskDocumentService.CreateTaskDocumentAsync(taskDocument);
            return CreatedAtAction(nameof(GetTaskDocuments), new { taskId = taskId }, taskDocument);
        }
    }


}
