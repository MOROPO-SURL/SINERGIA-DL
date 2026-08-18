using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Detail;

public record EconomicActivityTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.EconomicActivityTraceDetailDto>;