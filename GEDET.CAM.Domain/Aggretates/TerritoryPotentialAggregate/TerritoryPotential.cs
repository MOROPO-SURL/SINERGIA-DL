using MOROPO.GEDET.CAM.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TerritoryPotentialAggregate;

public class TerritoryPotential : AbstractAuditableEntity<TerritoryPotentialId>, IAggregateRoot<TerritoryPotentialId>, IArchivableEntity<TerritoryPotentialId>
{
    private TerritoryPotential() : base(new TerritoryPotentialId(default)) { }

    public TerritoryPotential(TerritoryPotentialId id, bool isArchived, string title, string? description): base(id)
    {
        IsArchived = isArchived;
        Title = title;
        Description = description;
    }

    public bool IsArchived { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
