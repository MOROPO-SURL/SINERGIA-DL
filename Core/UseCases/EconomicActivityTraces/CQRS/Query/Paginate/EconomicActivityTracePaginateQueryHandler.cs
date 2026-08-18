using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Paginate;

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