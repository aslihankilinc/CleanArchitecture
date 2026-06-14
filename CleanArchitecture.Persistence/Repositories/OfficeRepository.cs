using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Repositories
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(CleanArcDbContext context) : base(context)
        {
        }
    }
}