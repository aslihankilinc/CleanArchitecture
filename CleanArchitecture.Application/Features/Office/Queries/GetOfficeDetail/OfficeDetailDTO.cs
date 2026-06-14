using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail
{
    public class OfficeDetailDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
