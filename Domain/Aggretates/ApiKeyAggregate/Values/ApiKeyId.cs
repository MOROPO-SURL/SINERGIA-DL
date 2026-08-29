using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;

public readonly record struct ApiKeyId(Guid Value) : IId<Guid>;
