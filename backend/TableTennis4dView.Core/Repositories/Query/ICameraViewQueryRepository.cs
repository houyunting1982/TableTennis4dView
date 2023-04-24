using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query.Base;

namespace TableTennis4dView.Core.Repositories.Query;

public interface ICameraViewQueryRepository : IQueryRepository<CameraView>
{
    Task<IQueryable<CameraView>> GetByTechniqueId(long tId);
}
