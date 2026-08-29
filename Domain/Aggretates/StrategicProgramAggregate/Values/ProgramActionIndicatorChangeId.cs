using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

public readonly record struct ProgramActionIndicatorChangeId(DateTime Value) : IId<DateTime>;