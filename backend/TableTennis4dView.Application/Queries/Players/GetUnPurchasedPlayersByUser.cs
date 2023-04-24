using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Queries.Players;


public class GetUnPurchasedPlayersByUserQuery: IRequest<IEnumerable<PlayerDto>>
{
    public string Id { get; private set; }
        
    public GetUnPurchasedPlayersByUserQuery(string Id)
    {
        this.Id = Id;
    }
}

public class GetUnPurchasedPlayersByUserHandler : IRequestHandler<GetUnPurchasedPlayersByUserQuery, IEnumerable<PlayerDto>>
{
    private readonly IPlayerQueryRepository _repository;
    private readonly IMapper _mapper;
    public GetUnPurchasedPlayersByUserHandler(IPlayerQueryRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlayerDto>> Handle(GetUnPurchasedPlayersByUserQuery request, CancellationToken cancellationToken) {
        var allOfficialPlayers = (await _repository.GetAllAsync()).Where(p => p.Ownership == Ownership.Official).AsEnumerable();
        var players = await _repository.GetByUserId(request.Id);
        var unPurchasedPlayers = allOfficialPlayers.Except(players).ToList();
        return _mapper.Map<IEnumerable<PlayerDto>>(unPurchasedPlayers);
    }
}
