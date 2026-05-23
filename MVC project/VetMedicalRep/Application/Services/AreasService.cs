using Application.DTOs.AreaDTO;
using Application.Interfaces;
using Domain.Entities;
using System;

namespace Application.Services
{
    public class AreasService : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AreasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AreaResponse> AddAreaAsync(AreaAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentException("Area name is required.");

            // DTO → Entity
            var area = request.ToArea(request);

            // Persist the area
            var savedArea = await _unitOfWork.AreaRepository.AddAsync(area);
            await _unitOfWork.SaveChangesAsync();

            // Entity → DTO
            return savedArea.ToAreaResponse();
        }
    }
}