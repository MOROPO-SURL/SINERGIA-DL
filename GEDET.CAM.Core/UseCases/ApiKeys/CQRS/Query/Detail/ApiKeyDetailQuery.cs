using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Query.Detail;

public record ApiKeyDetailQuery(Guid Id) : IDetailQuery<ApiKeyId, Guid, DTOs.ApiKeyDetailDto>;
