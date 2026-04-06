using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TerritorialBarrierAggregate;

public class TerritorialBarrier : AbstractAuditableEntity<TerritorialBarrierId>, IAggregateRoot<TerritorialBarrierId>, IArchivableEntity<TerritorialBarrierId>
{
    private TerritorialBarrier() : base(new TerritorialBarrierId(default)) { }

    public TerritorialBarrier(TerritorialBarrierId id, bool isArchived, string title, string? description): base(id)
    {
        IsArchived = isArchived;
        Title = title;
        Description = description;
    }

    public bool IsArchived { get; set ; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
