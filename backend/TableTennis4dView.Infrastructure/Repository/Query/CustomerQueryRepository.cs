using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Query.Base;

namespace TableTennis4dView.Infrastructure.Repository.Query
{
    // QueryRepository class for customer
    public class CustomerQueryRepository : QueryRepository<Customer>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(TableTennis4dViewAppContext context) : base(context)
        {

        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync() {
            return (await GetAll()).ToList();
        }
        
        public async Task<Customer?> GetCustomerByEmail(string email) {
            return (await Find(i => i.Email == email)).FirstOrDefault();
        }
    }
}
