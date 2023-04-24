using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Entities.Identity;
using TableTennis4dView.Core.Repositories.Query;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Query.Base;

namespace TableTennis4dView.Infrastructure.Repository.Query;

public class PlayerQueryRepository : QueryRepository<Player>, IPlayerQueryRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    public PlayerQueryRepository(TableTennis4dViewAppContext context, UserManager<ApplicationUser> userManager) : base(context) {
        _userManager = userManager;
    }
    public async Task<IQueryable<Player>> GetAllAsync() {
        return (await GetAll()).Include(i => i.Techniques);
    }

    public async Task<IEnumerable<Player>> GetByUserId(string uId) {
        var user = await _userManager.Users
            .Include(u => u.Players)
            .ThenInclude(p => p.Techniques)
            .ThenInclude(t => t.CameraViews)
            .FirstOrDefaultAsync(x => x.Id == uId);
        return user?.Players ?? Enumerable.Empty<Player>();
    }
}
