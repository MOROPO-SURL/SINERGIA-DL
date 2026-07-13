using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Detail;

internal sealed class MacroprogramTraceDetailQueryHandler :
AbstractDetailQueryHandler<MacroprogramTrace, TraceId, long, MacroprogramTraceDetailQuery, MacroprogramTraceDetailDto>,
IRequestHandler<MacroprogramTraceDetailQuery, MacroprogramTraceDetailDto>
{
    public MacroprogramTraceDetailQueryHandler(IMacroprogramTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
