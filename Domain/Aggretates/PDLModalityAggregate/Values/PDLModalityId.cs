using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

public readonly record struct PDLModalityId(Guid Value) : IId<Guid>;