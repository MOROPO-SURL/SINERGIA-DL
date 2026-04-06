using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public sealed class ApiKeyPermissionBridge : IBridge<ApiKey, ApiKeyId, Guid, Permission, PermissionId, string>, IPersistenceSignable
{
    public ApiKeyPermissionBridge(ApiKeyId mainId, PermissionId linkedId)
    {
        MainId = mainId;
        LinkedId = linkedId;
    }

    public ApiKeyId MainId { get; set; }
    public ApiKey? Main { get; set; }

    public PermissionId LinkedId { get; set; }
    public Permission? Linked { get; set; }

    public string Signature { get; set; } = null!;

    public object GetSignableEntityModel()
    {
        return new { MainId, LinkedId };
    }
}
