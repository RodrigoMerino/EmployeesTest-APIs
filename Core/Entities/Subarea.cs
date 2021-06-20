using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Subarea
    {
        public Subarea()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string SubareaName { get; set; }
        public int? IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
