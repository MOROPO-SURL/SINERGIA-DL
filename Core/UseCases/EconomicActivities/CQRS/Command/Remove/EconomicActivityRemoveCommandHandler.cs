using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Remove;

internal sealed class EconomicActivityRemoveCommandHandler :
    AbstractRemoveCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityRemoveCommand>,
    IRequestHandler<EconomicActivityRemoveCommand>
{
    public EconomicActivityRemoveCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}