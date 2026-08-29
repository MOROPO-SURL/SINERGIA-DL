using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;

internal sealed class StrategicAxeCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeCreateCommand, StrategicAxeDetailDto>,
    IRequestHandler<StrategicAxeCreateCommand, StrategicAxeDetailDto>
{
    public StrategicAxeCreateCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IStrategicAxeQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}