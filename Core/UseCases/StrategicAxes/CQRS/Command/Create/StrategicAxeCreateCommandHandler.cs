using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;

internal sealed class StrategicAxeCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeCreateCommand, StrategicAxeDetailDto>,
    IRequestHandler<StrategicAxeCreateCommand, StrategicAxeDetailDto>
{
    public StrategicAxeCreateCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IStrategicAxeQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}