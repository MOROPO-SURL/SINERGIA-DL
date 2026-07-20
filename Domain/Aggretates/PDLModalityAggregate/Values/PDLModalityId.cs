using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;

public readonly record struct PDLModalityId(Guid Value) : IId<Guid>;