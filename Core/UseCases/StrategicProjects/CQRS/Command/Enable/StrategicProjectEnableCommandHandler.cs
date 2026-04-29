using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Enable;

internal sealed class StrategicProjectEnableCommandHandler :
    AbstractEnableCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectEnableCommand>,
    IRequest<StrategicProjectEnableCommand>
{
    public StrategicProjectEnableCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IStrategicProjectQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}