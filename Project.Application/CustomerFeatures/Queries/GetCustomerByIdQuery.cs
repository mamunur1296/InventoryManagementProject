using MediatR;
using Project.Application.DTOs;

namespace Project.Application.CustomerFeatures.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
