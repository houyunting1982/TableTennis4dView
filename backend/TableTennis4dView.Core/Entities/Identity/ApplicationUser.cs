using Microsoft.AspNetCore.Identity;

namespace TableTennis4dView.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
