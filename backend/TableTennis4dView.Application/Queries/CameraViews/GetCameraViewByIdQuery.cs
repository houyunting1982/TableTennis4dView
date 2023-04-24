using MediatR;
using TableTennis4dView.Application.DTOs.CameraView;

namespace TableTennis4dView.Application.Queries.CameraViews;

public class GetCameraViewByIdQuery: IRequest<CameraViewDto?>
{
    public long Id { get; private set; }
        
    public GetCameraViewByIdQuery(long Id)
    {
        this.Id = Id;
    }
}

public class GetCameraViewByIdHandler : IRequestHandler<GetCameraViewByIdQuery, CameraViewDto?>
{
    private readonly IMediator _mediator;

    public GetCameraViewByIdHandler(IMediator mediator) {
        _mediator = mediator;
    }

    public async Task<CameraViewDto?> Handle(GetCameraViewByIdQuery request, CancellationToken cancellationToken) {
        var cameraViews = await _mediator.Send(new GetAllCameraViewsQuery(), cancellationToken);
        var selectedCv = cameraViews.FirstOrDefault(x => x.Id == request.Id);
        return selectedCv;
    }
}
