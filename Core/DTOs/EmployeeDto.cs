using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? IdArea { get; set; }
        public int? IdSubarea { get; set; }

    }
}
