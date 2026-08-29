using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Remove;

internal sealed class ObjectiveRemoveCommandHandler :
    AbstractRemoveCommandHandler<Objective, ObjectiveId, Guid, ObjectiveRemoveCommand>,
    IRequestHandler<ObjectiveRemoveCommand>
{
    public ObjectiveRemoveCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IMapper mapper) 
        : base(entityCommandRepository, mapper)
    {
    }
}
