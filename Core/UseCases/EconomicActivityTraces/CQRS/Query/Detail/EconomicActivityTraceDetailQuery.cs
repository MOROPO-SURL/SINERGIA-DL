using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Detail;

public record EconomicActivityTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.EconomicActivityTraceDetailDto>;