using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.CustomerFeatures.Queries;
using Project.Domain.Abstractions;

namespace Project.Application.Features.CustomerFeatures.Handlers.QueryHandlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public GetCustomerByEmailHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.customerQueryRepository.GetCustomerByEmail(request.Email);
            var newData = _mapper.Map<CustomerDTO>(data);
            return newData;
        }
    }
}
