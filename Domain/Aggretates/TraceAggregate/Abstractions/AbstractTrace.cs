using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Abstractions;

public abstract class AbstractTrace<TEntity, TId, TIdValue> : AbstractEntity<TraceId, long>, IPersistenceSignable
    where TEntity : AbstractEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
{
    protected AbstractTrace() : base(new TraceId(default)) { }

    protected AbstractTrace(TraceId id, TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, TId? targetId = null, TEntity? target = null) : base(id)
    {
        Kind = kind;
        Author = author;
        CreatedAt = createAt;
        Target = target;
        TargetId = targetId;
        BeforeData = beforeData;
        AfterData = afterData;
        Signature = signature;
    }

    public TraceKind Kind { get; set; }

    public string Author { get; set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public TEntity? Target { get; set; }

    public TId? TargetId { get; set; }

    public string? BeforeData { get; set; }

    public string? AfterData { get; set; }

    public string Signature { get; set; } = null!;

    public virtual object GetSignableEntityModel()
    {
        return new { Id, Kind, Author, CreatedAt, BeforeData, AfterData, TargetId };
    }
}