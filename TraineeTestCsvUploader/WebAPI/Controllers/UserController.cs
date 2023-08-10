using Application.Features.UserFeatures.CreateUserCSV;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUserCSV")]
        public async Task<ActionResult<List<CreateUserCSVResponse>>> CreateUserCSV([FromQuery]CreateUserCSVRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
