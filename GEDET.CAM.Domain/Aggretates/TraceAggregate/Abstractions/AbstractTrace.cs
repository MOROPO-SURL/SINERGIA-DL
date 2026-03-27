using MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate.Abstractions;

public abstract class AbstractTrace<TEntity, TEntityId> : AbstractEntity<TraceId>, IPersistenceSignable where TEntity : AbstractEntity<TEntityId>
{
    protected AbstractTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, TEntity target, TEntityId targetId, string signature, string? beforeData, string? afterData) : base(id)
    {
        Kind = kind;
        Author = author;
        CreateAt = createAt;
        Target = target;
        TargetId = targetId;
        BeforeData = beforeData;
        AfterData = afterData;
        Signature = signature;
    }

    public Enumerations.TraceKind Kind { get; set; }

    public string Author { get; set; }

    public DateTime CreateAt { get; private set; }

    public TEntity Target { get; set; }

    public TEntityId TargetId { get; set; }

    public string? BeforeData { get; set; }

    public string? AfterData { get; set; }

    public string Signature { get; set; }

    public virtual object GetSignableEntityModel()
    {
        return new { Id, Kind, Author, CreateAt, BeforeData, AfterData };
    }
}
