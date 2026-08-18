using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectTraces.CQRS.Query.Detail;

public record StrategicProjectTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.StrategicProjectTraceDetailDto>;