using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Detail;

internal sealed class StrategicProjectIdeaTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceDetailQuery, StrategicProjectIdeaTraceDetailDto>,
    IRequestHandler<StrategicProjectIdeaTraceDetailQuery, StrategicProjectIdeaTraceDetailDto>
{
    public StrategicProjectIdeaTraceDetailQueryHandler(IStrategicProjectIdeaTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}