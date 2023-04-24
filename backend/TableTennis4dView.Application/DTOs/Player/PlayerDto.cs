using TableTennis4dView.Application.DTOs.Technique;

namespace TableTennis4dView.Application.DTOs.Player;

public class PlayerDtoSlim
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Ownership { get; set; }
    public string DominantHand { get; set; }
    public int TechniqueCount { get; set; }
}

public class PlayerDto : PlayerDtoSlim
{
    public ICollection<TechniqueDtoSlim> Techniques { get; set; }
}

public class PlayerDtoFull : PlayerDtoSlim
{
    public ICollection<TechniqueDto> Techniques { get; set; }
}
