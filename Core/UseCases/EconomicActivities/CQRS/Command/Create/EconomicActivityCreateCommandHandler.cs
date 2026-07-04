using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Create;

internal sealed class EconomicActivityCreateCommandHandler :
    AbstractCreateCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityCreateCommand, EconomicActivityDetailDto>,
    IRequestHandler<EconomicActivityCreateCommand, EconomicActivityDetailDto>
{
    public EconomicActivityCreateCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IEconomicActivityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}