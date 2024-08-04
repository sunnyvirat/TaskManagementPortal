using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Services
{
    public class TaskDocumentService : ITaskDocumentService
    {
        private readonly ITaskDocumentRepository _taskDocumentRepository;

        public TaskDocumentService(ITaskDocumentRepository taskDocumentRepository)
        {
            _taskDocumentRepository = taskDocumentRepository;
        }

        public async Task<IEnumerable<TaskDocument>> GetTaskDocumentsAsync(int taskId)
        {
            try
            {
                return await _taskDocumentRepository.GetTaskDocumentsAsync(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving documents for task with ID {taskId}", ex);
            }
        }

        public async Task CreateTaskDocumentAsync(TaskDocument taskDocument)
        {
            try
            {
                await _taskDocumentRepository.CreateTaskDocumentAsync(taskDocument);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task document", ex);
            }
        }
    }

}
