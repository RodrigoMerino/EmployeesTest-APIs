using Core.Custom_Entities;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task CreateEmployee(Employee employee)
        {
            await _employeeRepository.CreateEmployee(employee);

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public Pagination<Employee> GetAllPaginated(int PageNumber, int PageSize)
        {
            return _employeeRepository.GetAllPaginated(PageNumber, PageSize);

        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public Task<bool> UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);

        }


    }
}
