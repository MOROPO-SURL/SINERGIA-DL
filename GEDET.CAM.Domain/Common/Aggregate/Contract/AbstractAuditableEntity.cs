namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public abstract class AbstractAuditableEntity<TId> : AbstractEntity<TId>
{
    protected AbstractAuditableEntity(TId id) : base(id)
    {
    }

    public DateTime CreateAt { get; private set; } = DateTime.Now;

    public DateTime? UpdateAt { get; set; }
}
