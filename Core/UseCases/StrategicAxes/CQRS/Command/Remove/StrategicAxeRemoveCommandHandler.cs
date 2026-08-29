using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Remove;

internal sealed class StrategicAxeRemoveCommandHandler :
    AbstractRemoveCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeRemoveCommand>,
    IRequestHandler<StrategicAxeRemoveCommand>
{
    public StrategicAxeRemoveCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}