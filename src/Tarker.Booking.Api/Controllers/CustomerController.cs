using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNum;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[TypeFilter(typeof(ExecptionManager))]
public class CustomerController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerModel model, [FromServices] ICreateCustomerCommand createCustomerCommand1)
    {
        var data = await createCustomerCommand1.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Registro creado con éxito"));

    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
    [FromBody] UpdateCustomerModel model,
    [FromServices] IUpdateCustomerCommand updateCustomerCommand1)
    {
        var data = await updateCustomerCommand1.Execute(model);

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro actualizado con éxito"));

    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId, [FromServices] IDeleteCustomerCommand deleteCustomerCommand1)
    {
        if (userId == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await deleteCustomerCommand1.Execute(userId);

        if (!data)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro eliminado con éxito"));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllCustomerQuery getAllCustomerQuery1)
    {
        var data = await getAllCustomerQuery1.Execute();

        if (data == null || data.Count == 0)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-doc-num/{docNum}")]
    public async Task<IActionResult> GetByDocNum(string docNum, [FromServices] IGetCustomerByDocNumQuery getCustomerByDocNumQuery)
    {
        if (docNum == "")
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getCustomerByDocNumQuery.Execute(docNum);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-id/{customerId}")]
    public async Task<IActionResult> GetById(int customerId, [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
    {
        if (customerId == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getCustomerByIdQuery.Execute(customerId);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }
}
