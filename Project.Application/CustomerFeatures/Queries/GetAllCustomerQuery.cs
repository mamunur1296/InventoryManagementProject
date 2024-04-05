using MediatR;
using Project.Application.DTOs;

namespace Project.Application.CustomerFeatures.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerDTO>>
    {
    }
}
