using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Paginate;

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


