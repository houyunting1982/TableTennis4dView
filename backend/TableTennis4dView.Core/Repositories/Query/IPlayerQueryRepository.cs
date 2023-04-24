using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query.Base;

namespace TableTennis4dView.Core.Repositories.Query;

public interface IPlayerQueryRepository : IQueryRepository<Player>
{
    Task<IQueryable<Player>> GetAllAsync();
    Task<IEnumerable<Player>> GetByUserId(string uId);
}
