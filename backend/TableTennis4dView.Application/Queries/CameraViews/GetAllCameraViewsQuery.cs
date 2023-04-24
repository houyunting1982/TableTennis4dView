using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs.CameraView;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Queries.CameraViews;

public class GetAllCameraViewsQuery : IRequest<IEnumerable<CameraViewDto>>
{ }

public class GetAllCameraViewsHandler : IRequestHandler<GetAllCameraViewsQuery, IEnumerable<CameraViewDto>>
{
    private readonly ICameraViewQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCameraViewsHandler(ICameraViewQueryRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CameraViewDto>> Handle(GetAllCameraViewsQuery request, CancellationToken cancellationToken) {
        var cvs = await _repository.GetAll();
        return _mapper.Map<IEnumerable<CameraViewDto>>(cvs);
    }
}
