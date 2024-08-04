using Microsoft.EntityFrameworkCore;
using TaskManagementPortal.DBContext;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementContext _context;

        public TaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetTasksAsync()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting tasks", ex);
            }
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            try
            {
                return await _context.Tasks.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting task with ID {id}", ex);
            }
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating task", ex);
            }
        }

        public async Task UpdateTaskAsync(Tasks task)
        {
            try
            {
                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating task", ex);
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    throw new Exception($"Task with ID {id} not found");
                }
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting task with ID {id}", ex);
            }
        }

        public async Task<IEnumerable<Tasks>> GetTasksByEmployeeIdAsync(int employeeId)
        {
            try
            {
                return await _context.Tasks
                                 .Where(t => t.AssignedTo == employeeId)
                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting tasks for employee with ID {employeeId}", ex);
            }
        }
    }

}
