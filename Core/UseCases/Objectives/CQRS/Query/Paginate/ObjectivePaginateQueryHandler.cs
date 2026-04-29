using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Paginate;

internal sealed class ObjectivePaginateQueryHandler :
    AbstractPaginateQueryHandler<Objective, ObjectiveId, Guid, ObjectivePaginateQuery, ObjectiveBasicDto>,
    IRequestHandler<ObjectivePaginateQuery, PaginateQueryResultModel<ObjectiveBasicDto>>
{
    public ObjectivePaginateQueryHandler(IObjectiveQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Objective, object>> OrderExpression => entity => entity.Index;
}
