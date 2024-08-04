using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITaskDocumentService
    {
        Task<IEnumerable<TaskDocument>> GetTaskDocumentsAsync(int taskId);
        Task CreateTaskDocumentAsync(TaskDocument taskDocument);
    }
}
