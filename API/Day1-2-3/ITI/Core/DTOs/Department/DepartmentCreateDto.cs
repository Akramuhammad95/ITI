using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Department
{
    public class DepartmentCreateDto
    {
        public string DepartmentName { get; set; }
        public int SupervisorID { get; set; }
    }
}
