using MediatR;
using TableTennis4dView.Application.Common.Interfaces;
using TableTennis4dView.Application.DTOs;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Application.Queries.Players;

namespace TableTennis4dView.Application.Queries.User
{
    public class GetUserDetailsQuery : IRequest<UserDetailsResponseDTO>
    {
        public string UserId { get; set; }
    }

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsResponseDTO>
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public GetUserDetailsQueryHandler(IIdentityService identityService, IMediator mediator) {
            _identityService = identityService;
            _mediator = mediator;
        }
        public async Task<UserDetailsResponseDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var (userId, fullName, userName, email, roles ) = await _identityService.GetUserDetailsAsync(request.UserId);
            var players = (await _mediator.Send(new GetPlayerByUserQuery(request.UserId))).Cast<PlayerDtoSlim>().ToList();
            return new UserDetailsResponseDTO() { Id = userId, FullName = fullName, UserName = userName, Email = email, Roles = roles, Players = players};
        }
    }
}
