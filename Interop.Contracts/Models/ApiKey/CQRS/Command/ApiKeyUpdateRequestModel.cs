namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.ApiKey.CQRS.Command;

public record ApiKeyUpdateRequestModel(Guid Id, string Name, DateTime ExpireAt, string[] Permissions, string? Description);