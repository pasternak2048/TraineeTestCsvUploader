using MediatR;

namespace Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}