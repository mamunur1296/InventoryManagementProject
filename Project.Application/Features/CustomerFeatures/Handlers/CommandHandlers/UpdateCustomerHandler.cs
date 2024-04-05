using AutoMapper;
using MediatR;
using Project.Application.Features.CustomerFeatures.Commands;
using Project.Domain.Abstractions;

namespace Project.Application.Features.CustomerFeatures.Handlers.CommandHandlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;
        private readonly IMapper _mapper;
        public UpdateCustomerHandler(IUnitOfWorkDb unitOfWorkDb, IMapper mapper)
        {
            _unitOfWorkDb = unitOfWorkDb;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
            return "customerRes";
        }
    }
}
