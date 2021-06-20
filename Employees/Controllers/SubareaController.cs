using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Employees.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubareaController : ControllerBase
    {
        private readonly ISubareaService _subareaService;
        private readonly IMapper _mapper;
        public SubareaController(ISubareaService subareaService, IMapper mapper)
        {
            _subareaService = subareaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubareas()
        {
            var subAreas = await _subareaService.GetSubareas();
            var subAreaDto = _mapper.Map<IEnumerable<SubareaDto>>(subAreas);
            var response = new ApiGenericResponse<IEnumerable<SubareaDto>>(subAreaDto);
            return Ok(response);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetSubareasById(int id)
        {
            var subAreas = await _subareaService.GetsubareasByid(id);
            var subAreaDto = _mapper.Map<IEnumerable<SubareaDto>>(subAreas);
            var response = new ApiGenericResponse<IEnumerable<SubareaDto>>(subAreaDto);
            return Ok(response);

        }
    }
}
