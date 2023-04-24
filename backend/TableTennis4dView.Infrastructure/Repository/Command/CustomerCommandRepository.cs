using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Command.Base;

namespace TableTennis4dView.Infrastructure.Repository.Command
{
    // Command Repository class for customer
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(TableTennis4dViewAppContext context) : base(context) { }
    }
}
