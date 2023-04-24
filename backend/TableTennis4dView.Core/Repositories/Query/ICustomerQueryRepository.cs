using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query.Base;

namespace TableTennis4dView.Core.Repositories.Query
{
    // Interface for CustomerQueryRepository
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer?> GetCustomerByEmail(string email);
    }
}
