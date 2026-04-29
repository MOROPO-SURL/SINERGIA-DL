using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Enable;

internal sealed class StrategicAxeEnableCommandHandler :
    AbstractEnableCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeEnableCommand>,
    IRequest<StrategicAxeEnableCommand>
{
    public StrategicAxeEnableCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IStrategicAxeQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}