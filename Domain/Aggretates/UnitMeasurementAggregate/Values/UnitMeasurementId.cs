using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

public readonly record struct UnitMeasurementId(Guid Value) : IId<Guid>;
