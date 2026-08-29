using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Update;

internal sealed class KeyVariableUpdateCommandHandler :
    AbstractUpdateCommandHandler<KeyVariable, KeyVariableId, Guid, KeyVariableUpdateCommand, KeyVariableDetailDto>,
    IRequestHandler<KeyVariableUpdateCommand, KeyVariableDetailDto>
{
    public KeyVariableUpdateCommandHandler(IKeyVariableQueryRepositoryPort entityQueryRepository, IKeyVariableCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}