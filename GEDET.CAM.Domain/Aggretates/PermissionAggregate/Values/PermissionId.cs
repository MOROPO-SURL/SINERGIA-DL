namespace MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;

public readonly record struct PermissionId(string Value) : Common.Aggregate.Intefaces.IId<string>;