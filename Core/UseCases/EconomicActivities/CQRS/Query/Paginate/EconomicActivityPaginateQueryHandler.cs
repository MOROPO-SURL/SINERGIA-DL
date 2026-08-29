using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Query.Paginate;

internal sealed class EconomicActivityPaginateQueryHandler :
    AbstractPaginateQueryHandler<EconomicActivity, EconomicActivityId, int, EconomicActivityPaginateQuery, EconomicActivityBasicDto>,
    IRequestHandler<EconomicActivityPaginateQuery, PaginateQueryResultModel<EconomicActivityBasicDto>>
{
    public EconomicActivityPaginateQueryHandler(IEconomicActivityQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}