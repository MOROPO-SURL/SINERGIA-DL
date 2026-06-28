using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.CQRS.Query.Detail;

internal sealed class KeyVariableTraceDetailQueryHandler :
AbstractDetailQueryHandler<KeyVariableTrace, TraceId, long, KeyVariableTraceDetailQuery, KeyVariableTraceDetailDto>,
IRequestHandler<KeyVariableTraceDetailQuery, KeyVariableTraceDetailDto>
{
    public KeyVariableTraceDetailQueryHandler(IKeyVariableTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
