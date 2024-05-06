using MediatR;
using Project.Application.Exceptions;
using Project.Application.Interfaces;
using Project.Application.Response;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Project.Application.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<Response<string>>
    {
        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Contact Number must contain only digits")]
        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<string>>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Response<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new Response<string>();

                var result = await _customerService.CreateCustomerAsync(request.FirstName, request.LastName, request.Email, request.ContactNumber, request.Address);

                if (result.isSucceed)
                {
                    response.Success = true;
                    response.Data = $"Customer id = {result.Id} created successfully!";
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    throw new BadRequestException("Failed to create customer. Please ensure all required fields are provided and try again.");
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
