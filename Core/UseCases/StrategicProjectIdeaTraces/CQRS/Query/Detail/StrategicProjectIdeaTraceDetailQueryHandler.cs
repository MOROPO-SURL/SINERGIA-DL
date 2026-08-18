using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Detail;

internal sealed class StrategicProjectIdeaTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceDetailQuery, StrategicProjectIdeaTraceDetailDto>,
    IRequestHandler<StrategicProjectIdeaTraceDetailQuery, StrategicProjectIdeaTraceDetailDto>
{
    public StrategicProjectIdeaTraceDetailQueryHandler(IStrategicProjectIdeaTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}