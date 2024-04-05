using AutoMapper;
using MediatR;
using Project.Application.Features.CustomerFeatures.Commands;
using Project.Domain.Abstractions;
using Project.Domain.Entities;

namespace Project.Application.Features.CustomerFeatures.Handlers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customerEntity = _mapper.Map<Customer>(request);
            await _unitOfWorkDb.customerCommandRepository.AddAsync(customerEntity);
            await _unitOfWorkDb.SaveAsync();
            return "Customer Created Successfully{customerEntity.id}";
        }
    }
}
