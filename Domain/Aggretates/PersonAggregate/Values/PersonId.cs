namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

public readonly record struct PersonId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;