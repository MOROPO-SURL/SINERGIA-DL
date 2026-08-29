using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

public readonly record struct TerritorialBarrierId(Guid Value) : IId<Guid>;

