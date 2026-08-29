using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;

public class TerritorialBarrier : AbstractAuditableEntity<TerritorialBarrierId, Guid>, IAggregateRoot<TerritorialBarrierId, Guid>, IArchivableEntity<TerritorialBarrierId, Guid>
{
    private TerritorialBarrier() : base(new TerritorialBarrierId(default)) { }

    public TerritorialBarrier(TerritorialBarrierId id, bool isArchived, string title, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Title = title;
        Description = description;
    }

    public bool IsArchived { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
