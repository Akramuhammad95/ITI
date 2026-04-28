using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class DepartmentWithEmployeesDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
