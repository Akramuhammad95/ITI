using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class UpdateEmployeeSalaryDto
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
    }
}
