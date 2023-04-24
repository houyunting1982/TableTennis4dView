using MediatR;
using TableTennis4dView.Application.DTOs.Player;

namespace TableTennis4dView.Application.Queries.Players;

public class GetPlayerByIdQuery: IRequest<PlayerDto?>
{
    public long Id { get; private set; }
        
    public GetPlayerByIdQuery(long Id)
    {
        this.Id = Id;
    }
}

public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDto?>
{
    private readonly IMediator _mediator;

    public GetPlayerByIdHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<PlayerDto?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken) {
        var players = await _mediator.Send(new GetAllPlayersQuery(), cancellationToken);
        var selectedPlayer = players.FirstOrDefault(x => x.Id == request.Id);
        return selectedPlayer;
    }
}
