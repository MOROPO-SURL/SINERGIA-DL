using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

public readonly record struct DevelopmentActorProfileProductionActivityId(Guid Value) : IId<Guid>;