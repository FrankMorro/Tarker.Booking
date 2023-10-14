using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.FirstName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.LastName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.UserName).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(x => x.Password).NotNull().MaximumLength(50).NotEmpty();
        }
    }
}
