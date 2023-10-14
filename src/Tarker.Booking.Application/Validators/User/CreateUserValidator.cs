using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.LastName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.UserName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.Password).NotNull().MaximumLength(50).NotEmpty();

        }
    }
}
