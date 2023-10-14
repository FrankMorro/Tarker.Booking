using AutoMapper;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingById;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNum;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region User
        CreateMap<UserEntity, CreateUserModel>().ReverseMap();
        CreateMap<UserEntity, UpdateUserModel>().ReverseMap();

        CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
        CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
        CreateMap<UserEntity, GetUserByUserPasswordModel>().ReverseMap();
        #endregion

        #region Customer
        CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
        CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();

        CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
        CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
        CreateMap<CustomerEntity, GetCustomerByDocNumModel>().ReverseMap();

        #endregion

        #region Booking
        CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();

        CreateMap<BookingEntity, GetAllBookingModel>().ReverseMap();

        CreateMap<BookingEntity, GetBookingByIdModel>().ReverseMap();

        #endregion
    }
}
