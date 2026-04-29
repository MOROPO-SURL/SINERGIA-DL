using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Disable;

internal sealed class StrategicProjectDisableCommandHandler :
    AbstractDisableCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectDisableCommand>,
    IRequestHandler<StrategicProjectDisableCommand>
{
    public StrategicProjectDisableCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IStrategicProjectQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}