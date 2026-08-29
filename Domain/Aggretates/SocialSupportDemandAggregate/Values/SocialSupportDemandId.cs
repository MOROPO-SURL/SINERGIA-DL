using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

public readonly record struct SocialSupportDemandId(Guid Value) : IId<Guid>;