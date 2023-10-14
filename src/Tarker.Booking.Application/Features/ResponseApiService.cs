using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.Application.Features;

public static class ResponseApiService
{
    public static BaseResponseModel Response(int ststusCode, object data = null, string message = null)
    {
        bool success = false;

        if (ststusCode >= 200 && ststusCode < 300)
            success = true;

        var result = new BaseResponseModel
        {
            StatusCode = ststusCode,
            Success = success,
            Message = message,
            Data = data
        };

        return result;

    }
}
