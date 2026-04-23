using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

internal sealed class ApiKeyPaginateQueryHandler :
    AbstractPaginateQueryHandler<ApiKey, ApiKeyId, Guid, ApiKeyPaginateQuery, ApiKeyBasicDto>,
    IRequestHandler<ApiKeyPaginateQuery, PaginateQueryResultModel<ApiKeyBasicDto>>
{
    public ApiKeyPaginateQueryHandler(IApiKeyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<ApiKey, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}