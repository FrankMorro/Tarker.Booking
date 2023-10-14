namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingById
{
    public class GetBookingByIdModel
    {
        public int BookingId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public int CustomerId { get; set; }

    }
}
