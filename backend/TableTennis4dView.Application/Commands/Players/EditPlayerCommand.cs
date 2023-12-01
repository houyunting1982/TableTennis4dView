using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;

namespace TableTennis4dView.Application.Commands.Players;

public class CreatePlayerCommand : IRequest<PlayerDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? NickName { get; set; }
    public string Sex { get; set; }
    public string Ownership { get; set; }
    public string DominantHand { get; set; }
}

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, PlayerDto>
{
    private readonly IPlayerCommandRepository _repository;
    private readonly IMapper _mapper;


    public CreatePlayerCommandHandler(IPlayerCommandRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PlayerDto> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = _mapper.Map<CreatePlayerCommand, Player>(request);
        var result = await _repository.AddAsync(player);
        return _mapper.Map<Player, PlayerDto>(result);
    }
}

