using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Command.Base;

namespace TableTennis4dView.Infrastructure.Repository.Command;

public class PlayerCommandRepository : CommandRepository<Player>, IPlayerCommandRepository
{
    public PlayerCommandRepository(TableTennis4dViewAppContext context) : base(context) { }
}
