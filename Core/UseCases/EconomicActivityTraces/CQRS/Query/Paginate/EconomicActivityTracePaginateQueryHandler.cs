using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Paginate;

internal sealed class EconomicActivityTracePaginateQueryHandler :
AbstractPaginateQueryHandler<EconomicActivityTrace, TraceId, long, EconomicActivityTracePaginateQuery, EconomicActivityTraceBasicDto>,
IRequestHandler<EconomicActivityTracePaginateQuery, PaginateQueryResultModel<EconomicActivityTraceBasicDto>>
{
    public EconomicActivityTracePaginateQueryHandler(IEconomicActivityTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<EconomicActivityTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}