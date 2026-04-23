using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Query.Paginate;

internal sealed class ClasificationPaginateQueryHandler :
    AbstractPaginateQueryHandler<Clasification, ClasificationId, Guid, ClasificationPaginateQuery, ClasificationBasicDto>,
    IRequestHandler<ClasificationPaginateQuery, PaginateQueryResultModel<ClasificationBasicDto>>
{
    public ClasificationPaginateQueryHandler(IClasificationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Clasification, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<Clasification, object>> OrderExpression => entity => entity.Priority;
}