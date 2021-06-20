using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Custom_Entities;
namespace Core.Interfaces
{
    public interface IEmployeeService
    {
        Pagination<Employee> GetAllPaginated(int PageNumber, int PageSize);

        Task CreateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<bool> UpdateEmployee(Employee employee);
    }
}
