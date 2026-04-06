namespace MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

public readonly record struct UserId(string Value): Common.Aggregate.Intefaces.IId<string>;