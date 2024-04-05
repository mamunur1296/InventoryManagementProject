using MediatR;
using Project.Application.DTOs;

namespace Project.Application.CustomerFeatures.Queries
{
    public class GetCustomerByEmailQuery : IRequest<CustomerDTO>
    {
        public GetCustomerByEmailQuery(string? email)
        {
            Email = email;
        }

        public string ? Email { get; private set; }
    }
}
