using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(CleanArcDbContext context) : base(context)
        {
        }
    }
}