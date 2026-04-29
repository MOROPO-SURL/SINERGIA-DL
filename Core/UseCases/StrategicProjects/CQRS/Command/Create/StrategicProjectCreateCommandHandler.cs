using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

internal sealed class StrategicProjectCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectCreateCommand, StrategicProjectDetailDto>,
    IRequestHandler<StrategicProjectCreateCommand, StrategicProjectDetailDto>
{
    public StrategicProjectCreateCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IStrategicProjectQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}