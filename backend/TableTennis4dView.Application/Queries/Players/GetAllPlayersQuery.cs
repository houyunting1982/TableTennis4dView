using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Queries.Players;

public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>>
{
    
}

public class GetAllPlayerHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>
{
    private readonly IPlayerQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetAllPlayerHandler(IPlayerQueryRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken) {
        return _mapper.Map<IEnumerable<PlayerDto>>((await _repository.GetAllAsync()).AsEnumerable());
    }
}
