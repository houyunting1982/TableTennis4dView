using TableTennis4dView.Application.DTOs.CameraView;

namespace TableTennis4dView.Application.DTOs.Technique;

public class TechniqueDto
{
    public long Id { get; set; }
    public long PlayerId { get; set; }
    public string Title { get; set; }
    public string SourcePath { get; set; }
}
