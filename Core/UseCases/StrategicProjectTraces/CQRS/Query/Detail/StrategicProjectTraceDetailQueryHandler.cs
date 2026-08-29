using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.CQRS.Query.Detail;

internal sealed class StrategicProjectTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectTrace, TraceId, long, StrategicProjectTraceDetailQuery, StrategicProjectTraceDetailDto>,
    IRequestHandler<StrategicProjectTraceDetailQuery, StrategicProjectTraceDetailDto>
{
    public StrategicProjectTraceDetailQueryHandler(IStrategicProjectTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}