using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectiveActionIndicatorId(Guid Value) : IId<Guid>;

