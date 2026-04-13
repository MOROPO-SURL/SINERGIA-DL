using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

internal sealed class ApiKeyPaginateQueryHandler :
    AbstractPaginateQueryHandler<ApiKey, ApiKeyId, Guid, ApiKeyPaginateQuery, ApiKeyBasicDto>,
    IRequestHandler<ApiKeyPaginateQuery, PaginateQueryResultModel<ApiKeyBasicDto>>
{
    public ApiKeyPaginateQueryHandler(IApiKeyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}