using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Ports.Repository;

public interface IApiKeyQueryRepositoryPort : IEntityQueryRepositoryPort<ApiKey, ApiKeyId, Guid>
{
}
