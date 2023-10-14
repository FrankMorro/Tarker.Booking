﻿using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().GreaterThan(0);
            RuleFor(x => x.FirstName).NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50).NotEmpty();
            RuleFor(x => x.LastName).NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50).NotEmpty();
            RuleFor(x => x.UserName).NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50).NotEmpty();
            RuleFor(x => x.Password).NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50).NotEmpty();
        }
    }
}