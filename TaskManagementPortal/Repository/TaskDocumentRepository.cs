using Microsoft.EntityFrameworkCore;
using TaskManagementPortal.DBContext;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Repository
{
    public class TaskDocumentRepository : ITaskDocumentRepository
    {
        private readonly TaskManagementContext _context;

        public TaskDocumentRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDocument>> GetTaskDocumentsAsync(int taskId)
        {
            try
            {
                return await _context.TaskDocuments.Where(d => d.TaskId == taskId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting documents for task with ID {taskId}", ex);
            }
        }

        public async Task CreateTaskDocumentAsync(TaskDocument taskDocument)
        {
            try
            {
                _context.TaskDocuments.Add(taskDocument);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task document", ex);
            }
        }
    }

}
