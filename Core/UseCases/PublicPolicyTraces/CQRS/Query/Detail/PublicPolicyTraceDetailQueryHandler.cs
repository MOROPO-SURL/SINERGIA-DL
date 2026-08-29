using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.CQRS.Query.Detail;

internal sealed class PublicPolicyTraceDetailQueryHandler :
    AbstractDetailQueryHandler<PublicPolicyTrace, TraceId, long, PublicPolicyTraceDetailQuery, PublicPolicyTraceDetailDto>,
    IRequestHandler<PublicPolicyTraceDetailQuery, PublicPolicyTraceDetailDto>
{
    public PublicPolicyTraceDetailQueryHandler(IPublicPolicyTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}