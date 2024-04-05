using AutoMapper;
using MediatR;
using Project.Application.CustomerFeatures.Queries;
using Project.Application.DTOs;
using Project.Domain.Abstractions;

namespace Project.Application.CustomerFeatures.Handlers.QueryHandlers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDTO>>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetAllCustomerHandler(IUnitOfWorkDb unitOfWorkDb,IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _unitOfWorkDb.customerQueryRepository.GetAllAsync();
            var data = dataList.Select(x => _mapper.Map<CustomerDTO>(x));
            return data; 
        }
    }
}
