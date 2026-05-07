using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Unarchive;

internal sealed class StrategicAxeUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeUnarchiveCommand>,
    IRequestHandler<StrategicAxeUnarchiveCommand>
{
    public StrategicAxeUnarchiveCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}