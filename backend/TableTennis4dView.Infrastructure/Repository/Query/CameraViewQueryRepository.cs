using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Query.Base;

namespace TableTennis4dView.Infrastructure.Repository.Query;

public class CameraViewQueryRepository : QueryRepository<CameraView>, ICameraViewQueryRepository
{
    public CameraViewQueryRepository(TableTennis4dViewAppContext context) : base(context) { }
    
    public async Task<IQueryable<CameraView>> GetByTechniqueId(long tId) {
        return await Find(i => i.TechniqueId == tId);
    }
}
