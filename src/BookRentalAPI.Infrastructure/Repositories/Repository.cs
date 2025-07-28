using BookRentalAPI.Domain.Interfaces;
using BookRentalAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookRentalAPI.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BookRentalDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(BookRentalDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task UpdateAsync(T entity) => _context.Entry(entity).State = EntityState.Modified;
        public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
    }
}