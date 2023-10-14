namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingById
{
    public interface IGetBookingByIdQuery
    {
        Task<GetBookingByIdModel> Execute(int bookingId);
    }
}
