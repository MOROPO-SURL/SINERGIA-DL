using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Query.Paginate;

internal sealed class PDLModalityPaginateQueryHandler :
    AbstractPaginateQueryHandler<PDLModality, PDLModalityId, Guid, PDLModalityPaginateQuery, PDLModalityBasicDto>,
    IRequestHandler<PDLModalityPaginateQuery, PaginateQueryResultModel<PDLModalityBasicDto>>
{
    public PDLModalityPaginateQueryHandler(IPDLModalityQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PDLModality, object>> OrderExpression => entity => entity.Priority;
}