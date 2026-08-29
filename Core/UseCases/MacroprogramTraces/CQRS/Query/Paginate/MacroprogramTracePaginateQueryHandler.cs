using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Paginate;

internal sealed class MacroprogramTracePaginateQueryHandler :
AbstractPaginateQueryHandler<MacroprogramTrace, TraceId, long, MacroprogramTracePaginateQuery, MacroprogramTraceBasicDto>,
IRequestHandler<MacroprogramTracePaginateQuery, PaginateQueryResultModel<MacroprogramTraceBasicDto>>
{
    public MacroprogramTracePaginateQueryHandler(IMacroprogramTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<MacroprogramTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}


