using MediatR;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

internal sealed class ApiKeyPaginateQueryHandler :
    AbstractPaginateQueryHandler<ApiKey, ApiKeyId, Guid, ApiKeyPaginateQuery, ApiKeyBasicDto>,
    IRequestHandler<ApiKeyPaginateQuery, PaginateQueryResultModel<ApiKeyBasicDto>>
{
    public ApiKeyPaginateQueryHandler(IApiKeyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}