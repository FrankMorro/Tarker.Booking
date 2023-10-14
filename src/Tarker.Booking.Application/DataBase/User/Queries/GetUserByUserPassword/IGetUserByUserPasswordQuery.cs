namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserPassword
{
    public interface IGetUserByUserPasswordQuery
    {
        Task<GetUserByUserPasswordModel> Execute(string userName, string password);
    }
}
