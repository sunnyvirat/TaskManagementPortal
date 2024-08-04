using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Tasks>> GetTasksAsync()
        {
            try
            {
                return await _taskRepository.GetTasksAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving tasks", ex);
            }
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            try
            {
                return await _taskRepository.GetTaskByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving task with ID {id}", ex);
            }
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            try
            {
                await _taskRepository.CreateTaskAsync(task);
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
                await _taskRepository.UpdateTaskAsync(task);
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
                await _taskRepository.DeleteTaskAsync(id);
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
                return await _taskRepository.GetTasksByEmployeeIdAsync(employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving tasks for employee with ID {employeeId}", ex);
            }
        }
    }

}
