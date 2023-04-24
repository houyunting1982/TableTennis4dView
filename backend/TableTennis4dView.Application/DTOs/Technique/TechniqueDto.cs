using TableTennis4dView.Application.DTOs.CameraView;

namespace TableTennis4dView.Application.DTOs.Technique;

public class TechniqueDtoSlim
{
    public long Id { get; set; }
    public long PlayerId { get; set; }
    public string Title { get; set; }
}
public class TechniqueDto : TechniqueDtoSlim
{
    public ICollection<CameraViewDto> CameraViews { get; set; }
}
