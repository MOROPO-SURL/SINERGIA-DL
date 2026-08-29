using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;

public readonly record struct PublicPolicyId(Guid Value) : IId<Guid>;

