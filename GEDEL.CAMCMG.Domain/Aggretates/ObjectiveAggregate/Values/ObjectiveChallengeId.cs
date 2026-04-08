namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

public readonly record struct ObjectiveChallengeId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;
