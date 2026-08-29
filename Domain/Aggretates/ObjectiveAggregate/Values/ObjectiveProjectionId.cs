namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectiveProjectionId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;