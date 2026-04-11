namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.ApiKey.DTOs;

public record ApiKeyDetailModel(Guid Id, string Name, DateTime ExpireAt, string? Host, string? Description, string[] Permissions) : ApiKeyBasiclModel(Id, Name, ExpireAt);
