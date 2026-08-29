using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

public abstract class AbstractAuditableEntity<TId, TIdValue> : AbstractEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    protected AbstractAuditableEntity(TId id) : base(id) { }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}