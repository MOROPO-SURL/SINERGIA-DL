using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectiveActionIndicatorChangeId(DateTime Value) : IId<DateTime>;

