using AutoMapper;
using MediatR;
using Project.Application.CustomerFeatures.Queries;
using Project.Application.DTOs;
using Project.Domain.Abstractions;

namespace Project.Application.CustomerFeatures.Handlers.QueryHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.customerQueryRepository.GetByIdAsync(request.Id);
            var newData = _mapper.Map<CustomerDTO>(data);
            return newData;
        }
    }
}
