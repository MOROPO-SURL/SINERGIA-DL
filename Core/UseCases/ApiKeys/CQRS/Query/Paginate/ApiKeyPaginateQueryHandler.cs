using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

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