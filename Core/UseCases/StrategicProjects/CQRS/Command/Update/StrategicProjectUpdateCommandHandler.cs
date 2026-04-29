using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

internal sealed class StrategicProjectUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectUpdateCommand, StrategicProjectDetailDto>,
    IRequestHandler<StrategicProjectUpdateCommand, StrategicProjectDetailDto>
{
    public StrategicProjectUpdateCommandHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository, IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}