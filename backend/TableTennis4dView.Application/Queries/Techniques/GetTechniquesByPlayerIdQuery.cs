using MediatR;
using TableTennis4dView.Application.DTOs.Technique;

namespace TableTennis4dView.Application.Queries.Techniques;

public class GetTechniquesByPlayerIdQuery : IRequest<List<TechniqueDto>>
{
    public long PlayerId { get; private set; }
    public GetTechniquesByPlayerIdQuery(long playerId) {
        PlayerId = playerId;
    }
}

public class GetTechniquesByPlayerIdHandler : IRequestHandler<GetTechniquesByPlayerIdQuery, List<TechniqueDto>>
{
    private IMediator _mediator;
    public GetTechniquesByPlayerIdHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<List<TechniqueDto>> Handle(GetTechniquesByPlayerIdQuery request, CancellationToken cancellationToken) {
        var techniques = await _mediator.Send(new GetAllTechniquesQuery(), cancellationToken);
        var selectedTechniques = techniques.Where(i => i.PlayerId == request.PlayerId).ToList();
        return selectedTechniques;
    }
}
