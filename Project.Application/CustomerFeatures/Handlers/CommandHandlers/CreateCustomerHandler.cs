using AutoMapper;
using MediatR;
using Project.Application.CustomerFeatures.Commands;
using Project.Application.Models;
using Project.Domain.Abstractions;
using Project.Domain.Entities;

namespace Project.Application.CustomerFeatures.Handlers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerModel>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<CustomerModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customerEntity = _mapper.Map<Customer>(request);
            await _unitOfWorkDb.customerCommandRepository.AddAsync(customerEntity);
            await _unitOfWorkDb.SaveAsync();
            var newCustomerReturn = _mapper.Map<CustomerModel>(customerEntity);
            return newCustomerReturn;
        }
    }
}
