using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Custom_Entities;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Pagination<Employee> GetAllPaginated(int PageNumber, int PageSize);

        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);

        Task<bool> UpdateEmployee(Employee employee);
        Task CreateEmployee(Employee employee);

    }
}
