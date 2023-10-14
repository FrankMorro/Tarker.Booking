﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserPassword;
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
        [FromServices] ICreateUserCommand createUserCommand,
        [FromServices] IValidator<CreateUserModel> validator)
    {
        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
        }

        var data = await createUserCommand.Execute(model);

        return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Registro creado con éxito"));

    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateUserModel model,
        [FromServices] IUpdateUserCommand updateUserCommand,
        [FromServices] IValidator<UpdateUserModel> validator)
    {
        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
        }

        var data = await updateUserCommand.Execute(model);

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro actualizado con éxito"));

    }

    [HttpPut("update-password")]
    public async Task<IActionResult> UpdatePassword(
        [FromBody] UpdateUserPasswordModel model,
        [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand,
        [FromServices] IValidator<UpdateUserPasswordModel> validator)
    {
        var validate = await validator.ValidateAsync(model);

        if (!validate.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
        }

        var data = await updateUserPasswordCommand.Execute(model);

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro actualizado con éxito"));

    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId, [FromServices] IDeleteUserCommand deleteUserCommand)
    {
        if (userId == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await deleteUserCommand.Execute(userId);

        if (!data)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Registro eliminado con éxito"));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllUserQuery getAllUserQuery)
    {
        var data = await getAllUserQuery.Execute();

        if (data == null || data.Count == 0)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-id/{userId}")]
    public async Task<IActionResult> GetById(int userId, [FromServices] IGetUserByIdQuery getUserByIdQuery)
    {
        if (userId == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
        }

        var data = await getUserByIdQuery.Execute(userId);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }

    [HttpGet("get-by-username-password/{userName}/{password}")]
    public async Task<IActionResult> GetByUserNamePassword(string userName, string password,
        [FromServices] IGetUserByUserPasswordQuery getUserByUserPasswordQuery,
        [FromServices] IValidator<(string, string)> validator)
    {
        var validate = await validator.ValidateAsync((userName, password));

        if (!validate.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
        }

        var data = await getUserByUserPasswordQuery.Execute(userName, password);

        if (data == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
        }

        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Datos obtenidos con éxito"));
    }
}
