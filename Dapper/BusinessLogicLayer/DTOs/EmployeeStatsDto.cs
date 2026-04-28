using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class EmployeeStatsDto
    {
        public int TotalEmployees { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal AverageSalary { get; set; }
    }
}
