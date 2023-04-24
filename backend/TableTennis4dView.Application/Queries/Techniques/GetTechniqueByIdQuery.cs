using MediatR;
using TableTennis4dView.Application.DTOs.Technique;

namespace TableTennis4dView.Application.Queries.Techniques;

public class GetTechniqueByIdQuery: IRequest<TechniqueDto?>
{
    public long Id { get; private set; }
        
    public GetTechniqueByIdQuery(long Id)
    {
        this.Id = Id;
    }
}

public class GetTechniqueByIdHandler : IRequestHandler<GetTechniqueByIdQuery, TechniqueDto?>
{
    private readonly IMediator _mediator;

    public GetTechniqueByIdHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<TechniqueDto?> Handle(GetTechniqueByIdQuery request, CancellationToken cancellationToken) {
        var techniques = await _mediator.Send(new GetAllTechniquesQuery(), cancellationToken);
        var selectedTechnique = techniques.FirstOrDefault(x => x.Id == request.Id);
        return selectedTechnique;
    }
}
