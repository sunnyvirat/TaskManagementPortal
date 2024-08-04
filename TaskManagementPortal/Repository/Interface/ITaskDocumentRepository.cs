using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITaskDocumentRepository
    {
        Task<IEnumerable<TaskDocument>> GetTaskDocumentsAsync(int taskId);
        Task CreateTaskDocumentAsync(TaskDocument taskDocument);
    }
}
