using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;

public class Macroprogram : AbstractAuditableEntity<MacroprogramId, Guid>, IAggregateRoot<MacroprogramId, Guid>, IArchivableEntity<MacroprogramId, Guid>
{
    private Macroprogram() : base(new MacroprogramId(default)) { }

    public Macroprogram(MacroprogramId id, bool isArchived, string title, int index, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Title = title;
        Index = index;
        Description = description;
    }

    public bool IsArchived { get; set; }

    public string Title { get; set; } = null!;

    public int Index { get; set; }

    public string? Description { get; set; }
}
