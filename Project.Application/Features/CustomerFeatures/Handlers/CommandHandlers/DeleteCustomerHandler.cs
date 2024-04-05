﻿using MediatR;
using Project.Application.Features.CustomerFeatures.Commands;
using Project.Domain.Abstractions;

namespace Project.Application.Features.CustomerFeatures.Handlers.CommandHandlers
{
    internal class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly IUnitOfWorkDb _unitOfWorkDb;

        public DeleteCustomerHandler(IUnitOfWorkDb unitOfWorkDb)
        {
            _unitOfWorkDb = unitOfWorkDb;
        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var date = await _unitOfWorkDb.customerQueryRepository.GetByIdAsync(request.Id);
            if (date == null)
            {
                return "Data not found";
            }
            await _unitOfWorkDb.customerCommandRepository.DeleteAsync(date);
            await _unitOfWorkDb.SaveAsync();
            return "Completed";
        }
    }
}