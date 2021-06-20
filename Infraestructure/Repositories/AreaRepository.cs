using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly EmployeesDBContext _context;

        public AreaRepository(EmployeesDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Area>> GetAreas()
        {
            var areas = await _context.Areas.ToListAsync();
            return areas;
        }
    }
}
