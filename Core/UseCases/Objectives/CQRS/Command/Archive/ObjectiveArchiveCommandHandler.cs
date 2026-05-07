using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Archive;

internal sealed class ObjectiveArchiveCommandHandler :
    AbstractArchiveCommandHandler<Objective, ObjectiveId, Guid, ObjectiveArchiveCommand>,
    IRequestHandler<ObjectiveArchiveCommand>
{
    public ObjectiveArchiveCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
