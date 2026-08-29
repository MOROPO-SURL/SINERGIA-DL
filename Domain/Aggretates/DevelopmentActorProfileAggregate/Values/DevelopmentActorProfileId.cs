using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

public readonly record struct DevelopmentActorProfileId(Guid Value) : IId<Guid>;