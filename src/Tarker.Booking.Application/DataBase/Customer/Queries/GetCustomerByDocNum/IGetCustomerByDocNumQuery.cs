namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNum
{
    public interface IGetCustomerByDocNumQuery
    {
        Task<GetCustomerByDocNumModel> Execute(string documentNumber);
    }
}
