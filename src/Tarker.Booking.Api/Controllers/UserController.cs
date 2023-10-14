using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[TypeFilter(typeof(ExecptionManager))]
public class UserController : ControllerBase
{

    [HttpPost("create")]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserModel model,
        [FromServices] ICreateUserCommand createUserCommand)
    {
        var data = await createUserCommand.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Registro creado con éxito"));

    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateUserModel model,
        [FromServices] IUpdateUserCommand updateUserCommand)
    {
        var data = await updateUserCommand.Execute(model);

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro actualizado con éxito"));

    }
}
