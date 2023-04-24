using MediatR;
using TableTennis4dView.Application.Common.Interfaces;

namespace TableTennis4dView.Application.Commands.User.Update;

public class AssignUserPurchasedPlayerCommand : IRequest<int>
{
    public string Id { get; set; }
    public long PlayerId { get; set; }
}

public class AssignUserPurchasedPlayerCommandHandler : IRequestHandler<AssignUserPurchasedPlayerCommand, int>
{
    private readonly IIdentityService _identityService;
    public AssignUserPurchasedPlayerCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    public async Task<int> Handle(AssignUserPurchasedPlayerCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.UpdateUserPlayer(request.Id, request.PlayerId);
        return result ? 1 : 0;
    }
}