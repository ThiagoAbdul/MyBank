using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Exceptions;
using MyBank.Models;

namespace MyBank.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T: EntityBase
    {

        protected DbSet<T> _dbSet;
        private AppDbContext _dbContext;

        protected RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Create(T t)
        {
           await _dbSet.AddAsync(t);
           return t;
        }

        public async Task Delete(Guid id)
        {
            T? found = await _dbSet
                .Where(t => t.Id == id && !t.Deleted)
                .FirstOrDefaultAsync() ?? throw new EntityNotFoundException();
            found.Deleted = true;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbSet.Where(t => !t.Deleted)
            .AsNoTracking()
            .ToArrayAsync();
        }

        public async Task<T?> FindById(Guid id)
        {
            return await _dbSet
            .Where(t => !t.Deleted)
            .FirstOrDefaultAsync();
        }
    }
}