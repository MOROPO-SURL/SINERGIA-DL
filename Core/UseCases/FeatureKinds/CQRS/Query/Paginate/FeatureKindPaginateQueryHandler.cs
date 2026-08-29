using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Query.Paginate;

internal sealed class FeatureKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<FeatureKind, FeatureKindId, Guid, FeatureKindPaginateQuery, FeatureKindBasicDto>,
    IRequestHandler<FeatureKindPaginateQuery, PaginateQueryResultModel<FeatureKindBasicDto>>
{
    public FeatureKindPaginateQueryHandler(IFeatureKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<FeatureKind, object>> OrderExpression => entity => entity.Priority;
}