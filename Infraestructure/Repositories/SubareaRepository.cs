using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Infraestructure.Repositories
{
    public class SubareaRepository : ISubareaRepository
    {


        private readonly EmployeesDBContext _context;

        public SubareaRepository(EmployeesDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subarea>> GetSubareas()
        {
            var subArea = await _context.Subareas.ToListAsync();
            return subArea;
        }

        public async Task<IEnumerable<Subarea>> GetsubareasByid(int areaId)
        {
            return await _context.Subareas.Where(x => x.IdArea == areaId).ToListAsync();
        }
    }
}
