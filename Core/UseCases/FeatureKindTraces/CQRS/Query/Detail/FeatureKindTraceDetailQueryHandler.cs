using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Query.Detail;

internal sealed class FeatureKindTraceDetailQueryHandler :
    AbstractDetailQueryHandler<FeatureKindTrace, TraceId, long, FeatureKindTraceDetailQuery, FeatureKindTraceDetailDto>,
    IRequestHandler<FeatureKindTraceDetailQuery, FeatureKindTraceDetailDto>
{
    public FeatureKindTraceDetailQueryHandler(IFeatureKindTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}