using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Paginate;

internal sealed class StrategicProjectKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindPaginateQuery, StrategicProjectKindBasicDto>,
    IRequestHandler<StrategicProjectKindPaginateQuery, PaginateQueryResultModel<StrategicProjectKindBasicDto>>
{
    public StrategicProjectKindPaginateQueryHandler(IStrategicProjectKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProjectKind, object>> OrderExpression => entity => entity.Priority;
}