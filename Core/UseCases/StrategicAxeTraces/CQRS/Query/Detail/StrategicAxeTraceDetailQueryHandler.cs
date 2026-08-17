using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxeTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxeTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxeTraces.CQRS.Query.Detail;

internal sealed class StrategicAxeTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicAxeTrace, TraceId, long, StrategicAxeTraceDetailQuery, StrategicAxeTraceDetailDto>,
    IRequestHandler<StrategicAxeTraceDetailQuery, StrategicAxeTraceDetailDto>
{
    public StrategicAxeTraceDetailQueryHandler(IStrategicAxeTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}