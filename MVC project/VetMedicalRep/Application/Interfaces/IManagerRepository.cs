using System.Threading.Tasks;

public interface IManagerRepository
{
    Task<Domain.Entities.Manager> AddManagerAsync(Domain.Entities.Manager manager);
}
