using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeyTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

internal sealed class ApiKeyTracePaginateQueryHandler :
    AbstractPaginateQueryHandler<ApiKeyTrace, TraceId, long, ApiKeyTracePaginateQuery, ApiKeyTraceBasicDto>,
    IRequestHandler<ApiKeyTracePaginateQuery, PaginateQueryResultModel<ApiKeyTraceBasicDto>>
{
    public ApiKeyTracePaginateQueryHandler(IApiKeyTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<ApiKeyTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}