namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.ApiKey.CQRS.Command;

public record ApiKeyCreateRequestModel(string Name, DateTime ExpirateAt, string[] Permissions, string? Description);
