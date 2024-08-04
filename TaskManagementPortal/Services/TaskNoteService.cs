using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Services
{
    public class TaskNoteService : ITaskNoteService
    {
        private readonly ITaskNoteRepository _taskNoteRepository;

        public TaskNoteService(ITaskNoteRepository taskNoteRepository)
        {
            _taskNoteRepository = taskNoteRepository;
        }

        public async Task<IEnumerable<TaskNote>> GetTaskNotesAsync(int taskId)
        {
            try
            {
                return await _taskNoteRepository.GetTaskNotesAsync(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving notes for task with ID {taskId}", ex);
            }
        }

        public async Task CreateTaskNoteAsync(TaskNote taskNote)
        {
            try
            {
                await _taskNoteRepository.CreateTaskNoteAsync(taskNote);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task note", ex);
            }
        }
    }

}
