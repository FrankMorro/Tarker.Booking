namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeModel
    {
        public int BookingId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public string CustomerDocNum { get; set; } = null!;
    }
}
