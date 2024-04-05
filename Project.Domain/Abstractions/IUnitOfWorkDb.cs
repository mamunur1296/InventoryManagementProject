using Project.Domain.Abstractions.CommandRepositories;
using Project.Domain.Abstractions.QueryRepositories;

namespace Project.Domain.Abstractions
{
    public interface IUnitOfWorkDb
    {
        ICustomerCommandRepository customerCommandRepository { get; }
        ICustomerQueryRepository customerQueryRepository { get; }
        Task SaveAsync();
    }
}
