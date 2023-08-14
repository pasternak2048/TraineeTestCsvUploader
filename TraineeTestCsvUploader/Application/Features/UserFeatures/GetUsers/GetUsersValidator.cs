using FluentValidation;

namespace Application.Features.UserFeatures.GetUsers
{
    public class GetUsersValidator : AbstractValidator<GetUsersRequest>
    {
        public GetUsersValidator()
        {
            RuleFor(p => p.MinSalary).GreaterThanOrEqualTo(0);
            RuleFor(p => p.MinDateOfBirth).GreaterThanOrEqualTo(new DateTime(1972, 01, 01));
        }
    }
}
