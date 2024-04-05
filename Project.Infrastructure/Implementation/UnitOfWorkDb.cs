using Project.Domain.Abstractions;
using Project.Domain.Abstractions.CommandRepositories;
using Project.Domain.Abstractions.QueryRepositories;
using Project.Infrastructure.DataContext;
using Project.Infrastructure.Implementation.Command;
using Project.Infrastructure.Implementation.Query;

namespace Project.Infrastructure.Implementation
{
    public class UnitOfWorkDb : IUnitOfWorkDb
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ICustomerCommandRepository customerCommandRepository { get; private set; }
        public ICustomerQueryRepository customerQueryRepository { get; private set; }
        public UnitOfWorkDb(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            customerCommandRepository = new CustomerCommandRepository(applicationDbContext);
            customerQueryRepository = new CustomerQueryRepository(applicationDbContext);
        }



        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
