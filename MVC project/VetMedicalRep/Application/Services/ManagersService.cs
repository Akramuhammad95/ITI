using Application.DTOs.ManagerDTO;
using Application.Interfaces;
using Domain.Entities;
using System;

namespace Application.Services
{
    public class ManagersService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ManagerResponse> AddManagerAsync(ManagerAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentException("Manager name is required.");

            if (string.IsNullOrEmpty(request.Email))
                throw new ArgumentException("Manager email is required.");

            // DTO → Entity
            var manager = request.ToManager(request);

            // Persist the manager
            var savedManager = await _unitOfWork.ManagerRepository.AddAsync(manager);
            await _unitOfWork.SaveChangesAsync();

            // Entity → DTO
            return savedManager.ToManagerResponse();
        }
    }
}