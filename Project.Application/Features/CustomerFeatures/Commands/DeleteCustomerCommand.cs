using MediatR;
using Project.Application.Exceptions;
using Project.Application.Interfaces;
using Project.Application.Response;
using System.Net;

namespace Project.Application.Features.CustomerFeatures.Commands
{
    public class DeleteCustomerCommand : IRequest<Response<string>>
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Response<string>>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Response<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();

            try
            {
                var result = await _customerService.DeleteCustomerAsync(request.Id);

                if (result)
                {
                    response.Success = true;
                    response.Data = $"Customer with ID {request.Id} has been deleted successfully.";
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    throw new NotFoundException($"Customer with ID {request.Id} was not found.");
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }

    }
}
