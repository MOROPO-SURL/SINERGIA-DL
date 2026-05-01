using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class UnitMeasurementTrace : Abstractions.AbstractTrace<UnitMeasurement, UnitMeasurementId, Guid>
{
    private UnitMeasurementTrace() { }

    public UnitMeasurementTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, UnitMeasurementId? targetId = null, UnitMeasurement? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}