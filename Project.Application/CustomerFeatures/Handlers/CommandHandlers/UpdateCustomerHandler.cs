using AutoMapper;
using MediatR;
using Project.Application.CustomerFeatures.Commands;
using Project.Application.Models;
using Project.Domain.Abstractions;

namespace Project.Application.CustomerFeatures.Handlers.CommandHandlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerModel>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateCustomerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<CustomerModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWorkDb.customerQueryRepository.GetByIdAsync(request.Id);
            if (data == null) return default;
            else
            {
                data.CreatedDate = DateTime.Now;
                data.FirstName = request.FirstName;
                data.LastName = request.LastName;
                data.Email = request.Email;
                data.Address = request.Address;
            }
            await _unitOfWorkDb.customerCommandRepository.UpdateAsync(data);
            await _unitOfWorkDb.SaveAsync();
            var customerRes = _mapper.Map<CustomerModel>(data);
            return customerRes;
        }
    }
}
