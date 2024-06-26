﻿using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Interfaces;

namespace Project.Application.Features.CustomerFeatures.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerDTO>>
    {
    }
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDTO>>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
            
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customerList = await _customerService.GetAllCustomerAsync();
                var customer = customerList.Select(x => new CustomerDTO
                {
                    Id = x.id,
                    Address = x.address,
                    ContactNumber = x.contactNumber,
                    Email = x.email,
                    FirstName = x.fullName,
                    LastName = x.fullName,
                }).ToList();
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
