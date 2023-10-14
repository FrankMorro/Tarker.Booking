using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNum
{
    public class GetCustomerByDocNumQuery : IGetCustomerByDocNumQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocNumQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocNumModel> Execute(string documentNumber)
        {
            var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber.Trim());

            return _mapper.Map<GetCustomerByDocNumModel>(entity);
        }
    }
}
