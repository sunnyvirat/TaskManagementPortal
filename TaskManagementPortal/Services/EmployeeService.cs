using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetEmployeesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employees", ex);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee with ID {id}", ex);
            }
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.CreateEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating employee", ex);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.UpdateEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee", ex);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employee with ID {id}", ex);
            }
        }
    }

}
