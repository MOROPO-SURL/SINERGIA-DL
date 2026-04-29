using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Archive;

internal sealed class StrategicAxeArchiveCommandHandler :
    AbstractArchiveCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeArchiveCommand>,
    IRequestHandler<StrategicAxeArchiveCommand>
{
    public StrategicAxeArchiveCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IStrategicAxeQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}