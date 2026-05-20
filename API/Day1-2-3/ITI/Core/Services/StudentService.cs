using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services
{
    public class StudentService
    {
        private readonly IUOW _uow;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        private const string cacheKey = "all_students";

        public StudentService(IUOW uow, IMemoryCache cache, IMapper mapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out IEnumerable<StudentDto> cached))
                return cached;

            var students = await _uow.StudentRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<StudentDto>>(students);

            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));

            return result;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id);

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateAsync(StudentCreateDto dto)
        {
            var department = await _uow.DepartmentRepository.GetByIdAsync(dto.DepartmentId);

            if (department == null)
                throw new Exception("Department not found");

            var entity = _mapper.Map<Student>(dto);

            var created = await _uow.StudentRepository.CreateAsync(entity);
            await _uow.CompleteAsync();

            _cache.Remove(cacheKey);

            return _mapper.Map<StudentDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, StudentCreateDto dto)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id);

            if (student == null) return false;

            _mapper.Map(dto, student);

            await _uow.StudentRepository.UpdateAsync(student);
            await _uow.CompleteAsync();

            _cache.Remove(cacheKey);

            return true;
        }
        public async Task<IEnumerable<StudentDto>> SearchByName(string name)
        {
            var students = await _uow.StudentRepository.SearchByName(name);
            if (students == null) return Enumerable.Empty<StudentDto>();
            return _mapper.Map<IEnumerable<StudentDto>>(students);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id);

            if (student == null) return false;

            await _uow.StudentRepository.DeleteAsync(student);
            await _uow.CompleteAsync();

            _cache.Remove(cacheKey);

            return true;
        }
    }
}