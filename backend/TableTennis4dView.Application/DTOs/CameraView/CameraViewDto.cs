namespace TableTennis4dView.Application.DTOs.CameraView;

public class CameraViewDto
{
    public long Id { get; set; }
    public int Number { get; set; }
    public string Resource { get; set; }
    public long TechniqueId { get; set; }
    public List<string> ParsedImages { get; set; } = new List<string>();
}
