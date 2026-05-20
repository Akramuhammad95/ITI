using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class Supervisor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }

    }
}
