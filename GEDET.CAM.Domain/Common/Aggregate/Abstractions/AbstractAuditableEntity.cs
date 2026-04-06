namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

public abstract class AbstractAuditableEntity<TId, TIdValue> : AbstractEntity<TId, TIdValue> where TId : struct, Intefaces.IId<TIdValue>
{
    protected AbstractAuditableEntity(TId id) : base(id) { }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}