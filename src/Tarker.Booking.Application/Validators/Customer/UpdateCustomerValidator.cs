using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.FullName).NotNull().MaximumLength(100).NotEmpty();
            RuleFor(x => x.DocumentNumber).NotNull().MaximumLength(10).NotEmpty();
        }
    }
}
