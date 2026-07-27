using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

public readonly record struct StrategicProjectIdeaId(Guid Value) : IId<Guid>;