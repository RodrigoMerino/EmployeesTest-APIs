﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubareaService
    {
        Task<IEnumerable<Subarea>> GetSubareas();
        Task<IEnumerable<Subarea>> GetsubareasByid(int id);

    }
}
