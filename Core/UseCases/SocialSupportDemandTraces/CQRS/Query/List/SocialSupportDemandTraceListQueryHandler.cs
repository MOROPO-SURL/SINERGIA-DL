using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.List;

internal sealed class SocialSupportDemandTraceListQueryHandler :
    AbstractListQueryHandler<SocialSupportDemandTrace, TraceId, long, SocialSupportDemandTraceDetailDto, SocialSupportDemandTraceListQuery>,
    IRequestHandler<SocialSupportDemandTraceListQuery, SocialSupportDemandTraceDetailDto[]>
{
    public SocialSupportDemandTraceListQueryHandler(ISocialSupportDemandTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<SocialSupportDemandTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}