using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Query.Paginate;

internal sealed class FeaturePaginateQueryHandler :
    AbstractPaginateQueryHandler<Feature, FeatureId, Guid, FeaturePaginateQuery, FeatureBasicDto>,
    IRequestHandler<FeaturePaginateQuery, PaginateQueryResultModel<FeatureBasicDto>>
{
    public FeaturePaginateQueryHandler(IFeatureQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Feature, object>> OrderExpression => entity => entity.Kind!.Priority;
}