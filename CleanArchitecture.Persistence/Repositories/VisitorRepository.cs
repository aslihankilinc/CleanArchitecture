using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(CleanArcDbContext context) : base(context)
        {
        }
    }
}