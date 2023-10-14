namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNum
{
    public class GetCustomerByDocNumModel
    {
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
