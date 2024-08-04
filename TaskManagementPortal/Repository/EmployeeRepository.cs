using Microsoft.EntityFrameworkCore;
using TaskManagementPortal.DBContext;
using TaskManagementPortal.Models;
using TaskManagementPortal.Services.Interface;

namespace TaskManagementPortal.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TaskManagementContext _context;

        public EmployeeRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting employees", ex);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting employee with ID {id}", ex);
            }
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
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
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    throw new Exception($"Employee with ID {id} not found");
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employee with ID {id}", ex);
            }
        }
    }

}
