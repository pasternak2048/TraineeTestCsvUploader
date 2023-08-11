using Application.Features.UserFeatures.CreateUser;
using Application.Features.UserFeatures.CreateUserCSV;
using Application.Features.UserFeatures.UpdateUser;
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


        [HttpPost("CreateUser")]
        public async Task<ActionResult<CreateUserResponse>> CreateUser([FromQuery] CreateUserRequest request)
        {
            return await _mediator.Send(request);
        }


        [HttpPost("UpdateUser")]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser(UpdateUserRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
