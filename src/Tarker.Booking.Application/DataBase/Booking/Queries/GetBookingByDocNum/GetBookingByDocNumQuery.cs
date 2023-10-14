using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocNum
{
    public class GetBookingByDocNumQuery : IGetBookingByDocNumQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingByDocNumQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetBookingByDocNumModel>> Execute(string docNum)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == docNum
                                select new GetBookingByDocNumModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerId = customer.CustomerId,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocNum = customer.DocumentNumber
                                }).ToListAsync();

            return result;
        }
    }
}
