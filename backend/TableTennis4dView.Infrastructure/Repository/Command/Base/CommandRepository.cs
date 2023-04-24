using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Core.Repositories.Command.Base;
using TableTennis4dView.Infrastructure.Data;

namespace TableTennis4dView.Infrastructure.Repository.Command.Base
{
    // Generic command repository class
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly TableTennis4dViewAppContext Context;

        public CommandRepository(TableTennis4dViewAppContext context)
        {
            Context = context;
        }

        // Insert
        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        // Update
        public async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
