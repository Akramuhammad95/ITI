using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;

namespace Core.Services
{
    public class CourseService
    {
        private readonly IUOW _uow;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public CourseService(IUOW uow, IMemoryCache cache, IMapper mapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
        }

        // =========================
        // GET ALL
        // =========================
        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            string cacheKey = "all_courses";

            if (_cache.TryGetValue(cacheKey, out IEnumerable<CourseDto> cachedCourses))
            {
                return cachedCourses;
            }

            var courses = await _uow.CourseRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<CourseDto>>(courses);

            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));

            return result;
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id);

            if (course == null)
                return null;

            return _mapper.Map<CourseDto>(course);
        }

        // =========================
        // GET BY NAME
        // =========================
        public async Task<CourseDto> GetCourseByNameAsync(string name)
        {
            var course = await _uow.CourseRepository.GetByNameAsync(name);

            if (course == null)
                return null;

            return _mapper.Map<CourseDto>(course);
        }

        // =========================
        // CREATE
        // =========================
        public async Task<CourseDto> CreateCourseAsync(CourseCreateDto courseDto)
        {
            if (courseDto == null)
                return null;

            var courseEntity = _mapper.Map<Course>(courseDto);

            var createdCourse = await _uow.CourseRepository.CreateAsync(courseEntity);
            await _uow.CompleteAsync();

            return _mapper.Map<CourseDto>(createdCourse);
        }

        // =========================
        // UPDATE
        // =========================
        public async Task<bool> UpdateCourseAsync(int id, CourseDto courseDto)
        {
            if (id != courseDto.Id)
                return false;

            var existingCourse = await _uow.CourseRepository.GetByIdAsync(id);

            if (existingCourse == null)
                return false;

            _mapper.Map(courseDto, existingCourse);

            await _uow.CourseRepository.UpdateAsync(existingCourse);
            await _uow.CompleteAsync();

            // invalidate cache
            _cache.Remove("all_courses");

            return true;
        }

        // =========================
        // DELETE
        // =========================
        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id);

            if (course == null)
                return false;

            await _uow.CourseRepository.DeleteAsync(course);
            await _uow.CompleteAsync();

            _cache.Remove("all_courses");

            return true;
        }
    }
}