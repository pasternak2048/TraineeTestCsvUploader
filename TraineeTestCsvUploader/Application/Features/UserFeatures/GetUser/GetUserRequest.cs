using MediatR;

namespace Application.Features.UserFeatures.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public Guid Id { get; set; }
    }
}