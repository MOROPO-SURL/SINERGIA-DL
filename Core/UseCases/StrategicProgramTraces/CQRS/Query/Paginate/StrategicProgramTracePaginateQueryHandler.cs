using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.CQRS.Query.Paginate;

internal sealed class StrategicProgramTracePaginateQueryHandler :
AbstractPaginateQueryHandler<StrategicProgramTrace, TraceId, long, StrategicProgramTracePaginateQuery, StrategicProgramTraceBasicDto>,
IRequestHandler<StrategicProgramTracePaginateQuery, PaginateQueryResultModel<StrategicProgramTraceBasicDto>>
{
    public StrategicProgramTracePaginateQueryHandler(IStrategicProgramTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProgramTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}