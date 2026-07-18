using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramProjectIdeaAggregate.Values;

public readonly record struct StrategicProjectIdeaId(Guid Value) : IId<Guid>;