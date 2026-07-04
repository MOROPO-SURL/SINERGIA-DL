using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Query.Paginate;

internal sealed class EconomicActivityPaginateQueryHandler :
    AbstractPaginateQueryHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityPaginateQuery, EconomicActivityBasicDto>,
    IRequestHandler<EconomicActivityPaginateQuery, PaginateQueryResultModel<EconomicActivityBasicDto>>
{
    public EconomicActivityPaginateQueryHandler(IEconomicActivityQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}