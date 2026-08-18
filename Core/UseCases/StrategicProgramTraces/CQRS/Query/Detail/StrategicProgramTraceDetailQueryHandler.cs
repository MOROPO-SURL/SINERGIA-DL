using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProgramTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProgramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProgramTraces.CQRS.Query.Detail;

internal sealed class StrategicProgramTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProgramTrace, TraceId, long, StrategicProgramTraceDetailQuery, StrategicProgramTraceDetailDto>,
    IRequestHandler<StrategicProgramTraceDetailQuery, StrategicProgramTraceDetailDto>
{
    public StrategicProgramTraceDetailQueryHandler(IStrategicProgramTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}