namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.ApiKey.DTOs;

public record ApiKeyDetailDtoModel(Guid Id, string Name, DateTime ExpireAt, string? Host, string? Description, string[] Permissions) : ApiKeyBasicDtoModel(Id, Name, ExpireAt);
