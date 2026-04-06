namespace MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

public readonly record struct RoleId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;