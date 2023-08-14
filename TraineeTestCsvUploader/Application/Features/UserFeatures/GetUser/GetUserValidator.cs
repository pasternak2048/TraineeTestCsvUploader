using FluentValidation;

namespace Application.Features.UserFeatures.GetUser
{
    public class GetUserValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty();
        }
    }
}
