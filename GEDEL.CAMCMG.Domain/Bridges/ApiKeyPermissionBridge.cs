using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public sealed class ApiKeyPermissionBridge : IBridge<ApiKey, ApiKeyId, Guid, Permission, PermissionId, string>, IPersistenceSignable
{
    public ApiKeyPermissionBridge(ApiKeyId mainId, PermissionId linkedId, ApiKey? main = null, Permission? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
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
