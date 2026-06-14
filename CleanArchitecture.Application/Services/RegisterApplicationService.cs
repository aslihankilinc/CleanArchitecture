using CleanArchitecture.Application.Utilies;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Features.Office.Command.CreateOffice;
using CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail;

namespace CleanArchitecture.Application.Services
{
    public static class RegisterApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator.Mediator>();
            //CreateOfficeCommandHandler:IRequestHandler<CreateOfficeCommand,Guid>
            services.AddScoped<IRequestHandler<CreateOfficeCommand, Guid>, CreateOfficeCommandHandler>();
            services.AddScoped<IRequestHandler<GetOfficeDetailQuery, OfficeDetailDTO>, GetOfficeDetailQueryHandler>();
            return services;

        }
    }
}
