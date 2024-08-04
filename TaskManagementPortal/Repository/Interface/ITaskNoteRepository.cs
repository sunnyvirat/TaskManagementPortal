using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITaskNoteRepository
    {
        Task<IEnumerable<TaskNote>> GetTaskNotesAsync(int taskId);
        Task CreateTaskNoteAsync(TaskNote taskNote);
    }
}
