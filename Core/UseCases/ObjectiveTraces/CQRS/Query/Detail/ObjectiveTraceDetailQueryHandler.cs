using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ObjectiveTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ObjectiveTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ObjectiveTraces.CQRS.Query.Detail;

internal sealed class ObjectiveTraceDetailQueryHandler :
AbstractDetailQueryHandler<ObjectiveTrace, TraceId, long, ObjectiveTraceDetailQuery, ObjectiveTraceDetailDto>,
IRequestHandler<ObjectiveTraceDetailQuery, ObjectiveTraceDetailDto>
{
    public ObjectiveTraceDetailQueryHandler(IObjectiveTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
