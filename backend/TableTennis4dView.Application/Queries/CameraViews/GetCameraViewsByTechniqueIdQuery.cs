using MediatR;
using TableTennis4dView.Application.DTOs.CameraView;

namespace TableTennis4dView.Application.Queries.CameraViews;

public class GetCameraViewsByTechniqueIdQuery : IRequest<List<CameraViewDto>>
{
    public long TechniqueId { get; private set; }
    public GetCameraViewsByTechniqueIdQuery(long techniqueId) {
        TechniqueId = techniqueId;
    }
}

public class GetCameraViewsByTechniqueIdHandler : IRequestHandler<GetCameraViewsByTechniqueIdQuery, List<CameraViewDto>>
{
    private IMediator _mediator;
    public GetCameraViewsByTechniqueIdHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<List<CameraViewDto>> Handle(GetCameraViewsByTechniqueIdQuery request, CancellationToken cancellationToken) {
        var cvs = await _mediator.Send(new GetAllCameraViewsQuery(), cancellationToken);
        var selectedCvs = cvs.Where(i => i.TechniqueId == request.TechniqueId).ToList();
        return selectedCvs;
    }
}
