using Application.DTOs.VisitDTO;
using Application.Interfaces;

namespace Application.Services
{
    public class VisitsService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VisitResponse> AddVisitAsync(VisitAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var visit = request.ToVisit();
            var savedVisit = await _unitOfWork.VisitRepository.AddAsync(visit);
            await _unitOfWork.SaveChangesAsync();

            return savedVisit.ToVisitResponse();
        }
    }
}
