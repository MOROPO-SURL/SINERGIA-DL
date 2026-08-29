namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectiveActionId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;
