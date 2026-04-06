using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Ports.Repository;

public interface IApiKeyPermissionBridgeCommandRepositoryPort : IBridgeCommandRepositoryPort<ApiKeyPermissionBridge, ApiKey, ApiKeyId, Guid, Permission, PermissionId, string>
{
}
