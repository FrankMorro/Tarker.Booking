namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocNum
{
    public interface IGetBookingByDocNumQuery
    {
        Task<List<GetBookingByDocNumModel>> Execute(string docNum);
    }
}
