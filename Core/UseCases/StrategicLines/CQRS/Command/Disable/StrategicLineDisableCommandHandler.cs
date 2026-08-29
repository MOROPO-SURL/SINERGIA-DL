using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Disable;

internal sealed class StrategicLineDisableCommandHandler : 
    AbstractDisableCommandHandler<StrategicLine, StrategicLineId, Guid, StrategicLineDisableCommand>,
    IRequestHandler<StrategicLineDisableCommand>
{
    public StrategicLineDisableCommandHandler(IStrategicLineCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}