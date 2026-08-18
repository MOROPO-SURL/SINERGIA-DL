using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Detail;

public record StrategicProjectIdeaTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.StrategicProjectIdeaTraceDetailDto>;