using Microsoft.EntityFrameworkCore;
using TaskManagementPortal.DBContext;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Repository
{
    public class TaskNoteRepository : ITaskNoteRepository
    {
        private readonly TaskManagementContext _context;

        public TaskNoteRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskNote>> GetTaskNotesAsync(int taskId)
        {
            try
            {
                return await _context.TaskNotes.Where(n => n.TaskId == taskId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting notes for task with ID {taskId}", ex);
            }
        }

        public async Task CreateTaskNoteAsync(TaskNote taskNote)
        {
            try
            {
                _context.TaskNotes.Add(taskNote);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task note", ex);
            }
        }
    }

}
