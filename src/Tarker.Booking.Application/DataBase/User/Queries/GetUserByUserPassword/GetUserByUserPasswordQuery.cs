using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserPassword;

public class GetUserByUserPasswordQuery : IGetUserByUserPasswordQuery
{
    private readonly IDataBaseService _dataBaseService;
    private readonly IMapper _mapper;

    public GetUserByUserPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
    {
        _dataBaseService = dataBaseService;
        _mapper = mapper;
    }

    public async Task<GetUserByUserPasswordModel> Execute(string userName, string password)
    {
        var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);

        return _mapper.Map<GetUserByUserPasswordModel>(entity);
    }
}
