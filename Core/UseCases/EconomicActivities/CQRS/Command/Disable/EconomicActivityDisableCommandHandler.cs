using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Disable;

internal sealed class EconomicActivityDisableCommandHandler :
    AbstractDisableCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityDisableCommand>,
    IRequestHandler<EconomicActivityDisableCommand>
{
    public EconomicActivityDisableCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}