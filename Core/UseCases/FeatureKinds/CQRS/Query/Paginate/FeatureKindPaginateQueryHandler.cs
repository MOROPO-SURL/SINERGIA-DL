using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Paginate;

internal sealed class FeatureKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<FeatureKind, FeatureKindId, Guid, FeatureKindPaginateQuery, FeatureKindBasicDto>,
    IRequestHandler<FeatureKindPaginateQuery, PaginateQueryResultModel<FeatureKindBasicDto>>
{
    public FeatureKindPaginateQueryHandler(IFeatureKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<FeatureKind, object>> OrderExpression => entity => entity.Priority;
}