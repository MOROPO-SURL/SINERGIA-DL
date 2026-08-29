using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

public readonly record struct SocialResponsabilityActionId(Guid Value) : IId<Guid>;