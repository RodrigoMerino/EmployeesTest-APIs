using Infraestructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Linq;
using Core.Custom_Entities;

namespace Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesDBContext _context;

        public EmployeeRepository(EmployeesDBContext context)
        {
            _context = context;
        }

        public async Task CreateEmployee(Employee employee)
        {

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employeeId = await GetEmployee(id);
            _context.Employees.Remove(employeeId);
            var row = await _context.SaveChangesAsync();
            return row > 0;
        }

        public Pagination<Employee> GetAllPaginated(int PageNumber, int PageSize)
        {
            var data = _context.Employees.Include(x => x.IdAreaNavigation).Include(x => x.IdSubareaNavigation).OrderByDescending(c => c.Id);

            var pagedData = Pagination<Employee>.Create(data, PageNumber, PageSize);
            return pagedData;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.FromSqlRaw<Employee>("getEmployeeById {0}", id).ToList().FirstOrDefault();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.Employees.FromSqlRaw<Employee>("getAllEmployees").ToListAsync();
            return employees;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var currentPost = await GetEmployee(employee.Id);
            currentPost.Name = employee.Name;
            currentPost.LastName = employee.LastName;
            currentPost.IdArea = employee.IdArea;
            currentPost.IdSubarea = employee.IdSubarea;
            currentPost.Document = employee.Document;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
