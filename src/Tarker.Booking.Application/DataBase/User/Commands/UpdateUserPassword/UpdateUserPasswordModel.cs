namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordModel
    {
        public int UserId { get; set; }
        public required string Password { get; set; }
    }
}
