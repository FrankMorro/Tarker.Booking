using FluentValidation;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetUserByUserPasswordValidator : AbstractValidator<(string, string)>
    {
        public GetUserByUserPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.Item2).NotNull().MaximumLength(50).NotEmpty();
        }
    }
}
