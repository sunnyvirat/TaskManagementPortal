using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITaskNoteService
    {
        Task<IEnumerable<TaskNote>> GetTaskNotesAsync(int taskId);
        Task CreateTaskNoteAsync(TaskNote taskNote);
    }
}
