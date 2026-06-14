using CleanArchitecture.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CleanArcDbContext context;
        public Repository(CleanArcDbContext context)
        {
            this.context = context;
        }
        public Task<T> AddAsync(T entity)
        {
            context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
