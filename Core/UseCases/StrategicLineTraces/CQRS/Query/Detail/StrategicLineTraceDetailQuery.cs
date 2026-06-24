using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLineTraces.CQRS.Query.Detail;

public record StrategicLineTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.StrategicLineTraceDetailDto>;

