using CleanArchitecture.Application.Features.Office.Command.CreateOffice;
using CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail;
using CleanArchitecture.Application.Utilies;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator mediator;

        public OfficeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeDetailDTO>> Get(Guid id)
        {
            var query = new GetOfficeDetailQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Set(CreateOfficeCommand office)
        {
            var command = new CreateOfficeCommand
            {
                Name = office.Name
            };
            var result = await mediator.Send(command);
            return Ok();
        }
    }
}