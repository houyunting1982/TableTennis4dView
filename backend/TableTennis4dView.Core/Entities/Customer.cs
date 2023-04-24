using TableTennis4dView.Core.Entities.Base;

namespace TableTennis4dView.Core.Entities
{
    // Customer entity 
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
