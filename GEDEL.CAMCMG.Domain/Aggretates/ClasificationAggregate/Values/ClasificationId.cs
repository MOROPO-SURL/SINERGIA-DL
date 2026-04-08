using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;

public readonly record struct ClasificationId(Guid Value) : IId<Guid>;