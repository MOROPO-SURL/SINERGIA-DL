using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Paginate;

internal sealed class ClassificationPaginateQueryHandler :
    AbstractPaginateQueryHandler<Classification, ClassificationId, Guid, ClassificationPaginateQuery, ClassificationBasicDto>,
    IRequestHandler<ClassificationPaginateQuery, PaginateQueryResultModel<ClassificationBasicDto>>
{
    public ClassificationPaginateQueryHandler(IClassificationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Classification, object>> OrderExpression => entity => entity.Priority;
}