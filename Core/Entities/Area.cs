using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Area
    {
        public Area()
        {
            Employees = new HashSet<Employee>();
            Subareas = new HashSet<Subarea>();
        }

        public int Id { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Subarea> Subareas { get; set; }
    }
}
