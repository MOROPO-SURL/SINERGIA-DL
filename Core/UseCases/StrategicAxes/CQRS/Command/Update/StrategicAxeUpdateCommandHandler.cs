using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;

internal sealed class StrategicAxeUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeUpdateCommand, StrategicAxeDetailDto>,
    IRequestHandler<StrategicAxeUpdateCommand, StrategicAxeDetailDto>
{
    public StrategicAxeUpdateCommandHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository, IStrategicAxeCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}