using BusinessLayer.DTOs;
using BusinessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface IEmployeeRepository
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
