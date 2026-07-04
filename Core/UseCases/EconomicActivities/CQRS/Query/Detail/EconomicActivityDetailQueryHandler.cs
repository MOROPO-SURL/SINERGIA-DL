using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Query.Detail;

internal sealed class EconomicActivityDetailQueryHandler :
    AbstractDetailQueryHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityDetailQuery, EconomicActivityDetailDto>,
    IRequestHandler<EconomicActivityDetailQuery, EconomicActivityDetailDto>
{
    public EconomicActivityDetailQueryHandler(IEconomicActivityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
