using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.CQRS.Query.Detail;

internal sealed class FeatureTraceDetailQueryHandler :
    AbstractDetailQueryHandler<FeatureTrace, TraceId, long, FeatureTraceDetailQuery, FeatureTraceDetailDto>,
    IRequestHandler<FeatureTraceDetailQuery, FeatureTraceDetailDto>
{
    public FeatureTraceDetailQueryHandler(IFeatureTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
