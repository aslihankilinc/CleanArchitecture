using CleanArchitecture.Application.Utilies;

namespace CleanArchitecture.Application.Features.Office.Command.CreateOffice
{
    public class CreateOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
