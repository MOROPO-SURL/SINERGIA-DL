using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.CQRS.Query.List;

internal sealed class MacroprogramTraceListQueryHandler :
    AbstractListQueryHandler<MacroprogramTrace, TraceId, long, MacroprogramTraceDetailDto, MacroprogramTraceListQuery>,
    IRequestHandler<MacroprogramTraceListQuery, MacroprogramTraceDetailDto[]>
{
    public MacroprogramTraceListQueryHandler(IMacroprogramTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<MacroprogramTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}