using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.Detail;

public record SocialSupportDemandTraceDetailQuery(long Id) : IDetailQuery<TraceId, long, DTOs.SocialSupportDemandTraceDetailDto>;