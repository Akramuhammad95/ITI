using AutoMapper;
using Core.DTOs;
using Core.DTOs.Department;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class DepartmentService
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public DepartmentService(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentCreateDto dto)
        {
            var entity = _mapper.Map<Department>(dto);

            await _uow.DepartmentRepository.CreateAsync(entity);
            await _uow.CompleteAsync();

            return _mapper.Map<DepartmentDto>(entity);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var data = await _uow.DepartmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(data);
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var data = await _uow.DepartmentRepository.GetByIdAsync(id);
            return _mapper.Map<DepartmentDto>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _uow.DepartmentRepository.GetByIdAsync(id);
            if (dept == null) return false;

            await _uow.DepartmentRepository.DeleteAsync(dept);
            await _uow.CompleteAsync();

            return true;
        }
    }
}