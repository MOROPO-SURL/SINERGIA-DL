namespace MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;

public readonly record struct OrganizationId(Guid Value): Common.Aggregate.Intefaces.IId<Guid>;