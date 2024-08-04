using TaskManagementPortal.Models;

namespace TaskManagementPortal.Services.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<Tasks>> GetTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<Tasks>> GetTasksByEmployeeIdAsync(int employeeId);
    }
}
