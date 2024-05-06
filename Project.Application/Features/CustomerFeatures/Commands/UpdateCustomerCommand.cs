using AutoMapper;
using MediatR;
using Project.Application.Exceptions;
using Project.Application.Interfaces;
using Project.Application.Response;
using Project.Domain.Abstractions;
using System.Net;


namespace Project.Application.Features.CustomerFeatures.Commands
{
    public class UpdateCustomerCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
    }
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Response<string>>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Response<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new Response<string>();
                var result = await _customerService.UpdateCustomerAsync(request.FirstName, request.LastName, request.ContactNumber, request.Address, request.Id);
                if (result.isSucceed)
                {
                    response.Success = true;
                    response.Data = $"Customer id = {result.id} Update successfully!";
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    throw new BadRequestException("Failed to Update customer. Please ensure all required fields are provided and try again.");
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
