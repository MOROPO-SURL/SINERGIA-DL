using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.Paginate;

internal sealed class SocialSupportDemandTracePaginateQueryHandler :
AbstractPaginateQueryHandler<SocialSupportDemandTrace, TraceId, long, SocialSupportDemandTracePaginateQuery, SocialSupportDemandTraceBasicDto>,
IRequestHandler<SocialSupportDemandTracePaginateQuery, PaginateQueryResultModel<SocialSupportDemandTraceBasicDto>>
{
    public SocialSupportDemandTracePaginateQueryHandler(ISocialSupportDemandTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<SocialSupportDemandTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}