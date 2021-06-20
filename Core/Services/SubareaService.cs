using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SubareaService : ISubareaService
    {
        private readonly ISubareaRepository _subareaRepository;
        public SubareaService(ISubareaRepository subareaRepository)
        {
            _subareaRepository = subareaRepository;
        }

        public async Task<IEnumerable<Subarea>> GetSubareas()
        {
            return await _subareaRepository.GetSubareas();
        }

        public async Task<IEnumerable<Subarea>> GetsubareasByid(int id)
        {
            return await _subareaRepository.GetsubareasByid(id);
        }
    }
}
