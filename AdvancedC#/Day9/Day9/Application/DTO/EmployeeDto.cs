using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTO
{
    public class EmployeeDto
    {
        public int SSN { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int DNO { get; set; }
        public DateTime BDate { get; set; }
        public string Address { get; set; }
        public Sex Gender { get; set; }
        public decimal Salary { get; set; }
    }
}