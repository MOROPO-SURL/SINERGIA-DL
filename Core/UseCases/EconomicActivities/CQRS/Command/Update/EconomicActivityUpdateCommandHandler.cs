using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Update;

internal sealed class EconomicActivityUpdateCommandHandler :
    AbstractUpdateCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityUpdateCommand, EconomicActivityDetailDto>,
    IRequestHandler<EconomicActivityUpdateCommand, EconomicActivityDetailDto>
{
    public EconomicActivityUpdateCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IEconomicActivityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}