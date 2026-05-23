using System.Threading.Tasks;

public interface IAreaRepository
{
    Task<Domain.Entities.Area> AddAreaAsync(Domain.Entities.Area area);
}
