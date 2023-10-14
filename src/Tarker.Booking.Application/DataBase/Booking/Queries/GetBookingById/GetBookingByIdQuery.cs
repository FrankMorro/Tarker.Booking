using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IGetBookingByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetBookingByIdModel> Execute(int bookingId)
        {
            var entity = await _dataBaseService.Booking.FirstOrDefaultAsync(x => x.BookingId == bookingId);

            return _mapper.Map<GetBookingByIdModel>(entity);
        }
    }
}
