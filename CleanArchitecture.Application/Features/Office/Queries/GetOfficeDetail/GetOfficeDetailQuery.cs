using CleanArchitecture.Application.Utilies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail
{
    public class GetOfficeDetailQuery : IRequest<OfficeDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
