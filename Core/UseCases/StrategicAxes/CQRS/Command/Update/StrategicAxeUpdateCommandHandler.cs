using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;

internal sealed class StrategicAxeUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeUpdateCommand, StrategicAxeDetailDto>,
    IRequestHandler<StrategicAxeUpdateCommand, StrategicAxeDetailDto>
{
    public StrategicAxeUpdateCommandHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository, IStrategicAxeCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}