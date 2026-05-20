using AutoMapper;
using Core.DTOs;
using Core.DTOs.Department;
using Core.Models;

namespace Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // =========================
            // STUDENT
            // =========================

            CreateMap<StudentCreateDto, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Department, opt => opt.Ignore());

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null))
                .ForMember(dest => dest.SupervisorName,
                    opt => opt.MapFrom(src => src.Department != null ? src.Department.Supervisor != null ? src.Department.Supervisor.Name : null : null));

            // =========================
            // DEPARTMENT
            // =========================

            CreateMap<DepartmentCreateDto, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Students, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DepartmentName));

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StudentsCount,
                    opt => opt.MapFrom(src => src.Students != null ? src.Students.Count : 0));

            // =========================
            // COURSE
            // =========================

            CreateMap<CourseCreateDto, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CourseDto, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Course, CourseDto>();
        }
    }
}