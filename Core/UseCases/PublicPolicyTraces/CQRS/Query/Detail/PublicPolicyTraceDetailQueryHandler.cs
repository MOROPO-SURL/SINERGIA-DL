using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicyTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicyTraces.CQRS.Query.Detail;

internal sealed class PublicPolicyTraceDetailQueryHandler :
    AbstractDetailQueryHandler<PublicPolicyTrace, TraceId, long, PublicPolicyTraceDetailQuery, PublicPolicyTraceDetailDto>,
    IRequestHandler<PublicPolicyTraceDetailQuery, PublicPolicyTraceDetailDto>
{
    public PublicPolicyTraceDetailQueryHandler(IPublicPolicyTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}