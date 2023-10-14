using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().MaximumLength(100).NotEmpty();
            RuleFor(x => x.DocumentNumber).NotNull().MaximumLength(10).NotEmpty();
        }
    }
}
