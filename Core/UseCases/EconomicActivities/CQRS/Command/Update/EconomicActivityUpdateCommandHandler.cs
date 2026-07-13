using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Update;

internal sealed class EconomicActivityUpdateCommandHandler :
    AbstractUpdateCommandHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityUpdateCommand, EconomicActivityDetailDto>,
    IRequestHandler<EconomicActivityUpdateCommand, EconomicActivityDetailDto>
{
    public EconomicActivityUpdateCommandHandler(IEconomicActivityCommandRepositoryPort entityCommandRepository, IEconomicActivityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}