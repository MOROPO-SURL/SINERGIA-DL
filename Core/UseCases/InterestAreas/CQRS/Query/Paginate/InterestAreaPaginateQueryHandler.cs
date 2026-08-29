using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Paginate;

internal sealed class InterestAreaPaginateQueryHandler: AbstractPaginateQueryHandler<InterestArea, InterestAreaId, Guid, InterestAreaPaginateQuery, InterestAreaBasicDto>,
IRequestHandler<InterestAreaPaginateQuery, PaginateQueryResultModel<InterestAreaBasicDto>>
{
    public InterestAreaPaginateQueryHandler(IInterestAreaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<InterestArea, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}
