using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Archive;

internal sealed class StrategicProjectArchiveCommandHandler :
    AbstractArchiveCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectArchiveCommand>,
    IRequestHandler<StrategicProjectArchiveCommand>
{
    public StrategicProjectArchiveCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}