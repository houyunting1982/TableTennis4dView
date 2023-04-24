using System.Linq.Expressions;

namespace TableTennis4dView.Core.Repositories.Query.Base
{
    // Generic repository for query
    public interface IQueryRepository <T> where T : class
    {
        // Generic repository for all if any
        Task<T?> GetByIdAsync(long id);
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> expression);
    }
}
