using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Paginate;

internal sealed class PDLModalityPaginateQueryHandler :
    AbstractPaginateQueryHandler<PDLModality, PDLModalityId, Guid, PDLModalityPaginateQuery, PDLModalityBasicDto>,
    IRequestHandler<PDLModalityPaginateQuery, PaginateQueryResultModel<PDLModalityBasicDto>>
{
    public PDLModalityPaginateQueryHandler(IPDLModalityQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PDLModality, object>> OrderExpression => entity => entity.Priority;
}