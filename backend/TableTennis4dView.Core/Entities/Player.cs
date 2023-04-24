using TableTennis4dView.Core.Entities.Base;
using TableTennis4dView.Core.Entities.Identity;

namespace TableTennis4dView.Core.Entities;

public class Player : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Sex Sex { get; set; }
    public Ownership Ownership { get; set; }
    public DominantHand DominantHand { get; set; }
    public virtual ICollection<Technique> Techniques { get; set; }
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } 
}

public enum Sex
{
    NotSet,
    Male,
    Female,
    Other
}

public enum Ownership
{
    NotSet,
    Official,
    Private,
}

public enum DominantHand
{
    NotSet,
    Left,
    Right,
    Both
}
