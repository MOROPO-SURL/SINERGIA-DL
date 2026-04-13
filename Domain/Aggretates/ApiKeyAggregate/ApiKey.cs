using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;

public sealed class ApiKey : AbstractAuditableEntity<ApiKeyId, Guid>, INamedEntity<ApiKeyId, Guid>
{
    private ApiKey() : base(new ApiKeyId(default)) { }

    public ApiKey(ApiKeyId id, string name, string token, bool isEnabled, DateTime expireAt, string? description = null, string? host = null) : base(id)
    {
        Name = name;
        Token = token;
        IsEnabled = isEnabled;
        ExpireAt = expireAt;
        Host = host;
        Description = description;
    }

    public string Name { get; set; } = null!;

    public string Token { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime ExpireAt { get; set; }

    public string? Host { get; set; }

    public string? Description { get; set; }

    public List<ApiKeyPermissionBridge> PermissionBridges { get; set; } = [];
}
