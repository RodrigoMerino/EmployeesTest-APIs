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
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;
        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            var areas = await _areaService.GetAreas();
            var areaDto = _mapper.Map<IEnumerable<AreaDto>>(areas);
            var response = new ApiGenericResponse<IEnumerable<AreaDto>>(areaDto);
            return Ok(response);
        }
    }
}
