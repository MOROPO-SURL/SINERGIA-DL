namespace MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;

public readonly record struct ImageId(Guid Value) : Common.Aggregate.Intefaces.IId<Guid>;