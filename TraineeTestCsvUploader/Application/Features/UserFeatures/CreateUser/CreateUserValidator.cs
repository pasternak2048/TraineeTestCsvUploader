using FluentValidation;

namespace Application.Features.UserFeatures.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Name).MaximumLength(128);
            RuleFor(p => p.Phone).Matches("^[0-9]+$");
            RuleFor(p => p.DateOfBirth).Must(x => x > new DateTime(1972, 01, 01));
            RuleFor(p => p.Salary).Must(x => x >= 0);
        }
    }
}
