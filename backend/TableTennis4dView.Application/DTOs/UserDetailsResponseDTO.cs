using TableTennis4dView.Application.DTOs.Player;

namespace TableTennis4dView.Application.DTOs
{
    public class UserDetailsResponseDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public IList<PlayerDtoSlim> Players { get; set; }
    }
}
