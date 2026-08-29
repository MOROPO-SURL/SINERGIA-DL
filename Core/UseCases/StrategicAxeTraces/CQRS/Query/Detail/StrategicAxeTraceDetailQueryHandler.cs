using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.CQRS.Query.Detail;

internal sealed class StrategicAxeTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicAxeTrace, TraceId, long, StrategicAxeTraceDetailQuery, StrategicAxeTraceDetailDto>,
    IRequestHandler<StrategicAxeTraceDetailQuery, StrategicAxeTraceDetailDto>
{
    public StrategicAxeTraceDetailQueryHandler(IStrategicAxeTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}