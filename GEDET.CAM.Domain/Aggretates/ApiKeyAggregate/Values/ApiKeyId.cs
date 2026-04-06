using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;

public readonly record struct ApiKeyId(Guid Value) : IId<Guid>;
