using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;

public class TerritoryPotential : AbstractAuditableEntity<TerritoryPotentialId, Guid>, IAggregateRoot<TerritoryPotentialId, Guid>, IArchivableEntity<TerritoryPotentialId, Guid>
{
    private TerritoryPotential() : base(new TerritoryPotentialId(default)) { }

    public TerritoryPotential(TerritoryPotentialId id, bool isArchived, string title, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Title = title;
        Description = description;
    }

    public bool IsArchived { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
