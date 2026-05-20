namespace Core.Interfaces
{
    public interface IGenericRepo<T>
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByNameAsync(string name);

        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        
        Task<IEnumerable<T>> SearchByName(string name);
    }
}