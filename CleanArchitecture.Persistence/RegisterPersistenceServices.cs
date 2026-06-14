using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArcDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();
            return services;
        }
    }
}