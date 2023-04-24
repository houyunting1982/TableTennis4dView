using TableTennis4dView.Core.Entities.Base;

namespace TableTennis4dView.Core.Entities;

public class CameraView : BaseEntity
{
    public int Number { get; set; }
    public string Resource { get; set; }
    public long TechniqueId { get; set; }
    public Technique Technique { get; set; }
}
