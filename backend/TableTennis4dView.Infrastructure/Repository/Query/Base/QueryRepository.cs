using System.Linq.Expressions;
using TableTennis4dView.Core.Repositories.Query.Base;
using TableTennis4dView.Infrastructure.Data;

namespace TableTennis4dView.Infrastructure.Repository.Query.Base
{
    // Generic Query repository class
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly TableTennis4dViewAppContext Context;
        public QueryRepository(TableTennis4dViewAppContext context) {
            Context = context;
        }

        public async Task<T?> GetByIdAsync(long id) {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAll() {
            return await Task.Run(() => Context.Set<T>());
        }

        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> expression) {
            return await Task.Run(() => Context.Set<T>().Where(expression));
        }
    }
}
