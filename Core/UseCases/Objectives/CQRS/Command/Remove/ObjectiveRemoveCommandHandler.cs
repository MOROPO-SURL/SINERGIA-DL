using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Remove;

internal sealed class ObjectiveRemoveCommandHandler :
    AbstractRemoveCommandHandler<Objective, ObjectiveId, Guid, ObjectiveRemoveCommand>,
    IRequestHandler<ObjectiveRemoveCommand>
{
    public ObjectiveRemoveCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IMapper mapper) 
        : base(entityCommandRepository, mapper)
    {
    }
}
