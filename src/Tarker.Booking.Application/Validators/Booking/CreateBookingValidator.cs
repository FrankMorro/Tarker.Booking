using FluentValidation;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Code).NotNull().MaximumLength(20).NotEmpty();
            RuleFor(x => x.Type).NotNull().MaximumLength(20).NotEmpty();
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0).NotEmpty();
            RuleFor(x => x.UserId).NotNull().GreaterThan(0).NotEmpty();
        }
    }
}
