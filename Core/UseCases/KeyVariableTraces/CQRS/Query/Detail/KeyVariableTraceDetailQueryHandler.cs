using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.CQRS.Query.Detail;

internal sealed class KeyVariableTraceDetailQueryHandler :
AbstractDetailQueryHandler<KeyVariableTrace, TraceId, long, KeyVariableTraceDetailQuery, KeyVariableTraceDetailDto>,
IRequestHandler<KeyVariableTraceDetailQuery, KeyVariableTraceDetailDto>
{
    public KeyVariableTraceDetailQueryHandler(IKeyVariableTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
