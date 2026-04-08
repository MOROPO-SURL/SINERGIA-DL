using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;

public readonly record struct ProgramExecutionProjectId(Guid Value) : IId<Guid>;