using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.Detail;

internal sealed class SocialSupportDemandTraceDetailQueryHandler :
    AbstractDetailQueryHandler<SocialSupportDemandTrace, TraceId, long, SocialSupportDemandTraceDetailQuery, SocialSupportDemandTraceDetailDto>,
    IRequestHandler<SocialSupportDemandTraceDetailQuery, SocialSupportDemandTraceDetailDto>
{
    public SocialSupportDemandTraceDetailQueryHandler(ISocialSupportDemandTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}