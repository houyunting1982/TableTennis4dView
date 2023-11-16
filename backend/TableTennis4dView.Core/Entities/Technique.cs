using TableTennis4dView.Core.Entities.Base;

namespace TableTennis4dView.Core.Entities;

public class Technique : BaseEntity
{
    public string Title { get; set; }
    public Player Player { get; set; }
    public long PlayerId { get; set; }
    public string SourcePath { get; set; }
}
