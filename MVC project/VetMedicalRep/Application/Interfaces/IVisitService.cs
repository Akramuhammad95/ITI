using Application.DTOs.VisitDTO;

namespace Application.Interfaces
{
    public interface IVisitService
    {
        Task<VisitResponse> AddVisitAsync(VisitAddRequest request);
    }
}
