using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

public readonly record struct KeyVariableId(Guid Value) : IId<Guid>;