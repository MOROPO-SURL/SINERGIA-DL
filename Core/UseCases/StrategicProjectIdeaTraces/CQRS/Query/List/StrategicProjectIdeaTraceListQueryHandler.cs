using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.List;

internal sealed class StrategicProjectIdeaTraceListQueryHandler :
    AbstractListQueryHandler<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceDetailDto, StrategicProjectIdeaTraceListQuery>,
    IRequestHandler<StrategicProjectIdeaTraceListQuery, StrategicProjectIdeaTraceDetailDto[]>
{
    public StrategicProjectIdeaTraceListQueryHandler(IStrategicProjectIdeaTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProjectIdeaTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}