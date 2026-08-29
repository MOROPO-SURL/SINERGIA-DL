using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;

internal sealed class KeyVariableRemoveCommandHandler :
    AbstractRemoveCommandHandler<KeyVariable, KeyVariableId, Guid, KeyVariableRemoveCommand>,
    IRequestHandler<KeyVariableRemoveCommand>
{
    public KeyVariableRemoveCommandHandler(IKeyVariableCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}