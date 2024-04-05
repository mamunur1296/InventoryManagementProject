using MediatR;
using Project.Application.Models;

namespace Project.Application.CustomerFeatures.Commands
{
    public class UpdateCustomerCommand : IRequest<CustomerModel>
    {
        public Guid Id { get; set; }
        public string ? FirstName { get; set; }
        public string ? LastName { get; set; }
        public string ? Email { get; set; }
        public string ? ContactNumber { get; set; }
        public string ? Address { get; set; }
    }
}
