using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.CQRS.Query.Paginate;

internal sealed class PublicPolicyTracePaginateQueryHandler :
AbstractPaginateQueryHandler<PublicPolicyTrace, TraceId, long, PublicPolicyTracePaginateQuery, PublicPolicyTraceBasicDto>,
IRequestHandler<PublicPolicyTracePaginateQuery, PaginateQueryResultModel<PublicPolicyTraceBasicDto>>
{
    public PublicPolicyTracePaginateQueryHandler(IPublicPolicyTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PublicPolicyTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}