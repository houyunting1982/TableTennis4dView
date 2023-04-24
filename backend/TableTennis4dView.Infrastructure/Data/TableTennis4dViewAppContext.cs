using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Entities.Identity;

namespace TableTennis4dView.Infrastructure.Data
{
    // Context class for command
    //public class AppContext : DbContext
    public class TableTennis4dViewAppContext : IdentityDbContext<ApplicationUser>
    {
        public TableTennis4dViewAppContext(DbContextOptions<TableTennis4dViewAppContext> options) : base (options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<CameraView> CameraViews { get; set; }
    }
}
