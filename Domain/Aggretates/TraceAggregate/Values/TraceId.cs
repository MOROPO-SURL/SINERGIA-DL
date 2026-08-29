namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

public readonly record struct TraceId(long Value) : Common.Aggregate.Intefaces.IId<long>;