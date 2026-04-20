namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectivActionId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;