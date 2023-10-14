using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocNum;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingById;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[TypeFilter(typeof(ExecptionManager))]
public class BookingController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(
        [FromBody] CreateBookingModel model,
        [FromServices] ICreateBookingCommand createBookingCommand,
        [FromServices] IValidator<CreateBookingModel> validator)
    {
        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
        }

        var data = await createBookingCommand.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Registro creado con éxito"));

    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllBookingQuery getAllBookingQuery)
    {
        var data = await getAllBookingQuery.Execute();

        if (data == null || data.Count == 0)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-doc-num")]
    public async Task<IActionResult> GetByDocNum([FromQuery] string docNumber, [FromServices] IGetBookingByDocNumQuery getBookingByDocNumQuery)
    {
        if (string.IsNullOrEmpty(docNumber))
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getBookingByDocNumQuery.Execute(docNumber);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-type")]
    public async Task<IActionResult> GetByType([FromQuery] string type, [FromServices] IGetBookingByTypeQuery getBookingByTypeQuery)
    {
        if (string.IsNullOrEmpty(type))
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getBookingByTypeQuery.Execute(type);

        if (data == null || data.Count == 0)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-id/{bookingId}")]
    public async Task<IActionResult> GetById(int bookingId, [FromServices] IGetBookingByIdQuery getBookingByIdQuery)
    {
        if (bookingId == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getBookingByIdQuery.Execute(bookingId);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

}
