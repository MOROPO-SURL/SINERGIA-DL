using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;

internal sealed class KeyVariableUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<KeyVariable, KeyVariableId, Guid, KeyVariableUnarchiveCommand>,
    IRequestHandler<KeyVariableUnarchiveCommand>
{
    public KeyVariableUnarchiveCommandHandler(IKeyVariableCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}