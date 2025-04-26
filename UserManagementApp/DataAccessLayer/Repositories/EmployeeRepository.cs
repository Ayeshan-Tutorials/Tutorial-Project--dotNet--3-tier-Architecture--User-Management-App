using BusinessLayer.DTOs;
using BusinessLayer.Entities;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var check = await _appDbContext.Employees
                .FirstOrDefaultAsync(x => x.Name.ToLower() == employee.Name.ToLower());

            if (check != null)
            {
                return new ServiceResponse(false, "User already exist");
            }

            await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "User added successfully");
        }


        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return new ServiceResponse(false, "User not found");
            }

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "User deleted successfully");

        }


        public async Task<List<Employee>> GetAsync()
        {
            return await _appDbContext.Employees.ToListAsync();
        }


        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _appDbContext.Employees.FindAsync(id);
        }


        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            _appDbContext.Update(employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "User updated successfully");
        }
    }
}
