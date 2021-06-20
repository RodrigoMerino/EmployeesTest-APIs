using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Mapping
{
    class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            //employee
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            //areas
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();

            //sub
            CreateMap<SubareaDto, Subarea>();
            CreateMap<Subarea, SubareaDto>();

        }
    }
}
