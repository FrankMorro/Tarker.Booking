namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public required string Code { get; set; }
        public required string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
