using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectTraces.CQRS.Query.Detail;

internal sealed class StrategicProjectTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectTrace, TraceId, long, StrategicProjectTraceDetailQuery, StrategicProjectTraceDetailDto>,
    IRequestHandler<StrategicProjectTraceDetailQuery, StrategicProjectTraceDetailDto>
{
    public StrategicProjectTraceDetailQueryHandler(IStrategicProjectTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}