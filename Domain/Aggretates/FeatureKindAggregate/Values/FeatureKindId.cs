using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;

public readonly record struct FeatureKindId(Guid Value) : IId<Guid>;