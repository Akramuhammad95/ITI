using Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e =>
                    EF.Property<string>(e, "Name") == name);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> SearchByName(string name)
        {
            return await _dbSet.Where(e => EF.Property<string>(e, "Name").Contains(name)).ToListAsync();
        }
    }
}