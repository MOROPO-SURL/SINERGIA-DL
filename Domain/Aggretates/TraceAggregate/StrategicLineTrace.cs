using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class StrategicLineTrace : AbstractEntity<TraceId, long>, IPersistenceSignable
{
    private StrategicLineTrace() : base(new TraceId(default)) { }

    public StrategicLineTrace(TraceId id, TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, StrategicLineId? targetPrimaryId = null, StrategicAxeId? targetSecoundaryId = null, StrategicLine? target = null) : base(id)
    {
        Kind = kind;
        Author = author;
        CreatedAt = createAt;
        Target = target;
        TargetPrimaryId = targetPrimaryId;
        TargetSecoundaryId = targetSecoundaryId;
        BeforeData = beforeData;
        AfterData = afterData;
        Signature = signature;
    }

    public TraceKind Kind { get; set; }

    public string Author { get; set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public StrategicLine? Target { get; set; }

    public StrategicLineId? TargetPrimaryId { get; set; }

    public StrategicAxeId? TargetSecoundaryId { get; set; }

    public string? BeforeData { get; set; }

    public string? AfterData { get; set; }

    public string Signature { get; set; } = null!;

    public virtual object GetSignableEntityModel()
    {
        return new { Id, Kind, Author, CreatedAt, BeforeData, AfterData, TargetPrimaryId, TargetSecoundaryId };
    }
}