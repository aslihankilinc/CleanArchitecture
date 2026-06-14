using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Application.Exception;
using CleanArchitecture.Application.Utilies;

namespace CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail
{
    public class GetOfficeDetailQueryHandler : IRequestHandler<GetOfficeDetailQuery,
        OfficeDetailDTO>
    {
        private readonly IOfficeRepository office;
        public GetOfficeDetailQueryHandler(IOfficeRepository office)
        {
            this.office = office;
        }
        public async Task<OfficeDetailDTO> Handle(GetOfficeDetailQuery request)
        {
            var office = await this.office.GetByIdAsync(request.Id);
            if (office is null)
            {
                throw new NotFoundException();
            }
            return new OfficeDetailDTO
            {
                Id = office.Id,
                Name = office.Name
            };
        }
    }
}
