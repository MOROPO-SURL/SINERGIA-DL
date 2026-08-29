using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.CQRS.Query.Detail;

public record StrategicLineTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.StrategicLineTraceDetailDto>;

