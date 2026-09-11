using Dplomty.BL.Dtos.StudentDtos;
using Dplomty.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.BL.Mapping
{
    public static class StudentMapping
    {
        public static GetStudentDto EntitiyToGetStudentDto(this Student s)
        {
            return new GetStudentDto
            {
                Name = s.Name,
                Age = s.Age,
            };
        }
    }
}
