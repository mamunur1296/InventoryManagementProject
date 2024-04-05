using MediatR;

namespace Project.Application.CustomerFeatures.Commands
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
