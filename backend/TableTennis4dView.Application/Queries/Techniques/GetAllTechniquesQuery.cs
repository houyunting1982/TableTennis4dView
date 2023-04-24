using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.Technique;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Queries.Techniques;

public class GetAllTechniquesQuery : IRequest<IEnumerable<TechniqueDto>>
{
    
}

public class GetAllTechniquesHandler : IRequestHandler<GetAllTechniquesQuery, IEnumerable<TechniqueDto>>
{
    private readonly ITechniqueQueryRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAllTechniquesHandler(ITechniqueQueryRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TechniqueDto>> Handle(GetAllTechniquesQuery request, CancellationToken cancellationToken) {
        var techniques = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TechniqueDto>>(techniques);
    }
}
