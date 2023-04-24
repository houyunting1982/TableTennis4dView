using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query.Base;

namespace TableTennis4dView.Core.Repositories.Query;

public interface  ITechniqueQueryRepository : IQueryRepository<Technique>
{
    Task<IQueryable<Technique>> GetAllAsync();
    Task<IQueryable<Technique>> GetByPlayerId(long pId);
}
