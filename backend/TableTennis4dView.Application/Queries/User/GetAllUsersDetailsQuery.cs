using MediatR;
using TableTennis4dView.Application.Common.Interfaces;
using TableTennis4dView.Application.DTOs;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Application.Queries.Players;

namespace TableTennis4dView.Application.Queries.User
{
    public class GetAllUsersDetailsQuery : IRequest<List<UserDetailsResponseDTO>>
    {
        //public string UserId { get; set; }
    }

    public class GetAllUsersDetailsQueryHandler : IRequestHandler<GetAllUsersDetailsQuery, List<UserDetailsResponseDTO>>
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public GetAllUsersDetailsQueryHandler(IIdentityService identityService, IMediator mediator) {
            _identityService = identityService;
            _mediator = mediator;
        }

        public async Task<List<UserDetailsResponseDTO>> Handle(GetAllUsersDetailsQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersAsync();
            var userDetails = users.Select(x => new UserDetailsResponseDTO()
            {
                Id = x.id,
                Email = x.email,
                UserName = x.userName
                //Roles = (IList<string>)_identityService.GetUserRolesAsync(x.id) // Converstion problem
            }).ToList();

            foreach (var user in userDetails)
            {
                user.Roles = await _identityService.GetUserRolesAsync(user.Id);
                user.Players = (await _mediator.Send(new GetPlayerByUserQuery(user.Id))).Cast<PlayerDtoSlim>().ToList();
            }
            return userDetails;
        }
    }
}
