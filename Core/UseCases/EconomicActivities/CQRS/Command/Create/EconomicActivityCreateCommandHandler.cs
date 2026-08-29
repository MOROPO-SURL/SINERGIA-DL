using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Create;

internal sealed class EconomicActivityCreateCommandHandler :
    AbstractCreateCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityCreateCommand, EconomicActivityDetailDto>,
    IRequestHandler<EconomicActivityCreateCommand, EconomicActivityDetailDto>
{
    public EconomicActivityCreateCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IEconomicActivityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}