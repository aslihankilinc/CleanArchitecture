using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly CleanArcDbContext context;
        public UnitOfWorkEFCore(CleanArcDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
