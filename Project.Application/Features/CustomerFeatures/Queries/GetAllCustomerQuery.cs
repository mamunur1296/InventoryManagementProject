using MediatR;
using Project.Application.DTOs;

namespace Project.Application.Features.CustomerFeatures.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerDTO>>
    {
    }
}
