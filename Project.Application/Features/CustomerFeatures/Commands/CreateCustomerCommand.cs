using MediatR;

namespace Project.Application.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }




    }
}
