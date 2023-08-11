using Application.Features.UserFeatures.CreateUser;
using Application.Features.UserFeatures.CreateUserCSV;
using Application.Features.UserFeatures.DeleteUser;
using Application.Features.UserFeatures.GetUsers;
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
        public async Task<ActionResult<List<CreateUserCSVResponse>>> CreateUserCSV([FromQuery]CreateUserCSVRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult<CreateUserResponse>> CreateUser([FromQuery] CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }


        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }


        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<GetUsersResponse>>> GetUsers([FromQuery] GetUsersRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

    }
}
