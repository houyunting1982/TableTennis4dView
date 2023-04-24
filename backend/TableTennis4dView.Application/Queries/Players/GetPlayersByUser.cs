using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Queries.Players;

public class GetPlayerByUserQuery: IRequest<IEnumerable<PlayerDto>>
{
    public string Id { get; private set; }
        
    public GetPlayerByUserQuery(string Id)
    {
        this.Id = Id;
    }
}

public class GetPlayerByUserHandler : IRequestHandler<GetPlayerByUserQuery, IEnumerable<PlayerDto>>
{
    private readonly IPlayerQueryRepository _repository;
    private readonly IMapper _mapper;
    public GetPlayerByUserHandler(IPlayerQueryRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlayerDto>> Handle(GetPlayerByUserQuery request, CancellationToken cancellationToken) {
        var players = await _repository.GetByUserId(request.Id);
        return _mapper.Map<IEnumerable<PlayerDto>>(players);
    }
}
