using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Query.Base;

namespace TableTennis4dView.Infrastructure.Repository.Query;

public class TechniqueQueryRepository : QueryRepository<Technique>, ITechniqueQueryRepository
{
    public TechniqueQueryRepository(TableTennis4dViewAppContext context) : base(context) { }

    public async Task<IQueryable<Technique>> GetAllAsync()
    {
        return (await GetAll())
            .Include(i => i.Player);
    }

    public async Task<IQueryable<Technique>> GetByPlayerId(long pId) {
        return await Find(i => i.PlayerId == pId);
    }
}
