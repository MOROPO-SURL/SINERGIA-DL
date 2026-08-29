using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Unarchive;

internal sealed class StrategicAxeUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeUnarchiveCommand>,
    IRequestHandler<StrategicAxeUnarchiveCommand>
{
    public StrategicAxeUnarchiveCommandHandler(IStrategicAxeCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}