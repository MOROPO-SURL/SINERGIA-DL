using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Query.Paginate;

public record ApiKeyPaginateQuery(int Page, int Limit, Expression<Func<ApiKey, bool>>? Criteria = null) : IPaginateQuery<ApiKey, ApiKeyId, Guid, ApiKeyBasicDto>;
