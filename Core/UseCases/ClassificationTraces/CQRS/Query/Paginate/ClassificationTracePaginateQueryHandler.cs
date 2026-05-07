using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ClassificationTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Paginate;

internal sealed class ClassificationTracePaginateQueryHandler :
    AbstractPaginateQueryHandler<ClassificationTrace, TraceId, long, ClassificationTracePaginateQuery, ClassificationTraceBasicDto>,
    IRequestHandler<ClassificationTracePaginateQuery, PaginateQueryResultModel<ClassificationTraceBasicDto>>
{
    public ClassificationTracePaginateQueryHandler(IClassificationTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<ClassificationTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}