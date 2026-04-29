using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Remove;

internal sealed class StrategicProjectRemoveCommandHandler :
    AbstractRemoveCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectRemoveCommand>,
    IRequestHandler<StrategicProjectRemoveCommand>
{
    public StrategicProjectRemoveCommandHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository, IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}