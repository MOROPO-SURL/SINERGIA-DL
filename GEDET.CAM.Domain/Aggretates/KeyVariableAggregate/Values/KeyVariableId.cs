namespace MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate.Values;

public readonly record struct KeyVariableId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;
