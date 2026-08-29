using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.Detail;

internal sealed class SocialSupportDemandTraceDetailQueryHandler :
    AbstractDetailQueryHandler<SocialSupportDemandTrace, TraceId, long, SocialSupportDemandTraceDetailQuery, SocialSupportDemandTraceDetailDto>,
    IRequestHandler<SocialSupportDemandTraceDetailQuery, SocialSupportDemandTraceDetailDto>
{
    public SocialSupportDemandTraceDetailQueryHandler(ISocialSupportDemandTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}