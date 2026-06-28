using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.CQRS.Query.Detail;

internal sealed class InterestAreaTraceDetailQueryHandler :
AbstractDetailQueryHandler<InterestAreaTrace, TraceId, long, InterestAreaTraceDetailQuery, InterestAreaTraceDetailDto>,
IRequestHandler<InterestAreaTraceDetailQuery, InterestAreaTraceDetailDto>
{
    public InterestAreaTraceDetailQueryHandler(IInterestAreaTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
