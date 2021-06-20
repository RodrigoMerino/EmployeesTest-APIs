﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Repositories;
using Core.Interfaces;
using Employees.Responses;
using Core.Entities;
using Core.Services;
using AutoMapper;
using Core.DTOs;
using Newtonsoft.Json;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetEmployees()
        //{
        //    var employess = await _employeeService.GetEmployees();
        //    var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employess);
        //    var response = new ApiGenericResponse<IEnumerable<EmployeeDto>>(employeeDto);
        //    return Ok(response);
        //}
        [HttpGet]
        public IActionResult GetAllPaginated(int PageNumber, int PageSize)
        {
            var orders = _employeeService.GetAllPaginated(PageNumber, PageSize);


            var metadata = new Metadata()
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                CurrentPage = orders.CurrentPage,
                TotalPages = orders.TotalPages

            };

            var response = new ApiGenericResponse<IEnumerable<Employee>>(orders)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Id = id;
            if (id == 0)
            {
                throw new Exception("id required");
            }
            else
            {
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result);

            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {

            var employee = await _employeeService.GetEmployee(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);

        }

        [HttpPost]
        public async Task<IActionResult> createEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeService.CreateEmployee(employee);

            employeeDto = _mapper.Map<EmployeeDto>(employee);
            var response = new ApiGenericResponse<EmployeeDto>(employeeDto);

            return Ok(response);

        }
    }


}
