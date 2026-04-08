using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;

public sealed class ApiKey : AbstractAuditableEntity<ApiKeyId, Guid>, INamedEntity<ApiKeyId, Guid>
{
    private ApiKey() : base(new ApiKeyId(default)) { }

    public ApiKey(ApiKeyId id, string name, string token, bool isEnabled, DateTime expirateAt, string? host = null) : base(id)
    {
        Name = name;
        Token = token;
        IsEnabled = isEnabled;
        ExpirateAt = expirateAt;
        Host = host;
    }

    public string Name { get; set; } = null!;

    public string Token { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime ExpirateAt { get; set; }

    public string? Host { get; set; }

    public List<ApiKeyPermissionBridge> PermissionBridges { get; set; } = [];
}
