using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class CustomEmployee
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
