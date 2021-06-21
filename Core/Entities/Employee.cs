using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? IdArea { get; set; }
        public int? IdSubarea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Subarea IdSubareaNavigation { get; set; }
    }
}
