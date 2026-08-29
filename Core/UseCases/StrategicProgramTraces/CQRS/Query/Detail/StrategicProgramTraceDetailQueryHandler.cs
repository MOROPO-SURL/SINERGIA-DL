using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.CQRS.Query.Detail;

internal sealed class StrategicProgramTraceDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProgramTrace, TraceId, long, StrategicProgramTraceDetailQuery, StrategicProgramTraceDetailDto>,
    IRequestHandler<StrategicProgramTraceDetailQuery, StrategicProgramTraceDetailDto>
{
    public StrategicProgramTraceDetailQueryHandler(IStrategicProgramTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}