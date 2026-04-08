using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Abstractions;

public abstract class AbstractTrace<TEntity, TId, TIdValue> : AbstractEntity<TraceId, long>, IPersistenceSignable
    where TEntity : AbstractEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
{
    protected AbstractTrace(TraceId id, TraceKind kind, string author, DateTime createAt, TEntity target, TId targetId, string signature, string? beforeData, string? afterData) : base(id)
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

    public TraceKind Kind { get; set; }

    public string Author { get; set; }

    public DateTime CreateAt { get; private set; }

    public TEntity Target { get; set; }

    public TId TargetId { get; set; }

    public string? BeforeData { get; set; }

    public string? AfterData { get; set; }

    public string Signature { get; set; }

    public virtual object GetSignableEntityModel()
    {
        return new { Id, Kind, Author, CreateAt, BeforeData, AfterData };
    }
}